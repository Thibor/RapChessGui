var version = '2020-04-02';
var piecePawn = 0x01;
var pieceKnight = 0x02;
var pieceBishop = 0x03;
var pieceRook = 0x04;
var pieceQueen = 0x05;
var pieceKing = 0x06;
var colorBlack = 0x08;
var colorWhite = 0x10;
var colorEmpty = 0x20;
var moveflagPassing = 0x02 << 16;
var moveflagCastleKing = 0x04 << 16;
var moveflagCastleQueen = 0x08 << 16;
var moveflagPromotion = 0xf0 << 16;
var moveflagPromoteQueen = 0x10 << 16;
var moveflagPromoteRook  = 0x20 << 16;
var moveflagPromoteBishop = 0x40 << 16;
var moveflagPromoteKnight = 0x80 << 16;
var maskCastle = moveflagCastleKing | moveflagCastleQueen;
var maskColor = colorBlack | colorWhite;
var adjMobility = 0;
var g_captured = 0;
var g_castleRights = 0xf;
var g_depth = 0;
var g_passing = 0;
var g_move50 = 0;
var g_moveNumber = 0;
var g_pv = '';
var g_totalNodes = 0;
var g_startTime = 0;
var g_inCheck = false;
var g_timeout = 0;
var g_nodeout = 0;
var g_stop = false;
var g_scoreFm = '';
var g_lastCastle = 0;
var undoStack = [];
var arrField = [];
var g_board = new Array(256);
var boardCheck = new Array(256);
var boardCastle = new Array(256);
var whiteTurn = 1;
var usColor = 0;
var enColor = 0;
var arrMaterial = [0,100,300,300,500,800,0xffff];
var arrDir = [[],[],[14,-14,18,-18,31,-31,33,-33],[15,-15,17,-17],[1,-1,16,-16],[1,-1,15,-15,16,-16,17,-17],[1,-1,15,-15,16,-16,17,-17]];
var arrMov = [0,0,1,7,7,7,1];

function StrToSquare(s){
return (('abcdefgh'.indexOf(s[0]) + 4) | (12 - parseInt(s[1])) << 4);
}
  
function FormatSquare(i){
return 'abcdefgh'[(i & 0xf) - 4] + (12 - (i >>4));
} 

function FormatMove(move){
var result = FormatSquare(move & 0xFF) + FormatSquare((move >> 8) & 0xFF);
if (move & moveflagPromotion){
	if (move & moveflagPromoteQueen) result += 'q';
	else if (move & moveflagPromoteRook) result += 'r';
	else if (move & moveflagPromoteBishop) result += 'b';
	else result += 'n';
}
return result;
}

function GetMoveFromString(moveString) {
var moves = GenerateAllMoves(whiteTurn);
for (var i = 0; i < moves.length; i++){
	if (FormatMove(moves[i]) == moveString)
		return moves[i];
}
}

function Initialize(){
arrField = [];
for(var n = 0; n < 256; n++){
	boardCheck[n] = 0;
	boardCastle[n]=15;
	g_board[n] = 0;
}
for(var y = 0;y < 8; y++)
	for(var x = 0;x < 8;x++)
		arrField.push((y + 4) * 16 + x + 4);
for(var n = 0;n < 6;n++){
	boardCastle[[68,72,75,180,184,187][n]] = [7,3,11,13,12,14][n];
	boardCheck[[71,72,73,183,184,185][n]] = [colorBlack | moveflagCastleQueen,colorBlack | maskCastle,colorBlack | moveflagCastleKing,colorWhite | moveflagCastleQueen,colorWhite | maskCastle,colorWhite | moveflagCastleKing][n];
}
}

function InitializeFromFen(fen){
for(var n = 0;n < 64;n++)
	g_board[arrField[n]] = colorEmpty;
if(!fen)fen = 'rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1';
var chunks = fen.split(' ');
var row = 0;
var col = 0;
var pieces = chunks[0];
for (var i = 0; i < pieces.length; i++){
	var c = pieces.charAt(i);
	if (c == '/') {
		row++;
		col = 0;
	}else if(c >= '0' && c <= '9')
		col += parseInt(c);
	else{
		var b = c.toLowerCase();
		var isWhite = b != c;
		var piece = isWhite ? colorWhite : colorBlack;
		var index = (row + 4) * 16 + col + 4;
		switch(b){
			case 'p':
				piece |= piecePawn;
			break;
			case 'b':
				piece |= pieceBishop;
			break;
			case 'n':
				piece |= pieceKnight;
			break;
			case 'r':
				piece |= pieceRook;
			break;
			case 'q':
				piece |= pieceQueen;
			break;
			case 'k':
				piece |= pieceKing;
			break;
		}
		g_board[index] = piece;
		col++;
	}
}
whiteTurn = chunks[1].charAt(0) == 'w' | 0;
g_castleRights = 0;
if (chunks[2].indexOf('K') != -1)
	g_castleRights |= 1;
if (chunks[2].indexOf('Q') != -1)
	g_castleRights |= 2;
if (chunks[2].indexOf('k') != -1)
	g_castleRights |= 4;
if (chunks[2].indexOf('q') != -1)
	g_castleRights |= 8;
g_passing = 0;
if (chunks[3].indexOf('-') == -1)
	g_passing = StrToSquare(chunks[3]);
g_move50 = parseInt(chunks[4]);
g_moveNumber = parseInt(chunks[5]);
if(g_moveNumber)g_moveNumber--;
g_moveNumber *= 2;
if(!whiteTurn)
	g_moveNumber++;
undoStack=[];
}

function GenerateMove(moves,fr,to,flag){
adjMobility++;
if(((g_board[to] & 7) == pieceKing) || ((g_lastCastle & maskCastle) && ((boardCheck[to] & g_lastCastle) == g_lastCastle)))
	g_inCheck = true;
else
	moves[moves.length] = fr | (to << 8) | flag;
}

function GenerateAllMoves(wt){
g_inCheck = false;
adjMobility = 0;
usColor = wt ?  colorWhite : colorBlack;
enColor = wt ? colorBlack : colorWhite;
var moves = [];
for(var n = 0;n < 64;n++){
	var fr = arrField[n];
	var f = g_board[fr];
	if(f & usColor)f &= 7;else continue;
	adjMobility += arrMaterial[f];
	if(f == 1){
		var del = wt ? -16 : 16;
		var to = fr + del;
		if(g_board[to] & colorEmpty){
			GeneratePwnMoves(moves,fr,to,true);
			if(!g_board[fr-del-del] && g_board[to + del] & colorEmpty)
				GeneratePwnMoves(moves,fr,to + del,true);
		}
		if(g_board[to - 1] & enColor)GeneratePwnMoves(moves,fr,to - 1,true);
		else if((to - 1) == g_passing)GeneratePwnMoves(moves,fr,g_passing,true,moveflagPassing);
		else if(g_board[to - 1] & colorEmpty)GeneratePwnMoves(moves,fr,to - 1,false);
		if(g_board[to + 1] & enColor)GeneratePwnMoves(moves,fr,to + 1,true);
		else if((to + 1) == g_passing)GeneratePwnMoves(moves,fr,g_passing,true,moveflagPassing);
		else if(g_board[to + 1] & colorEmpty)GeneratePwnMoves(moves,fr,to + 1,false);
	}else{
		GenerateUniMoves(moves,fr,arrDir[f],arrMov[f]);
		if(f == 6){
			var cr = wt ? g_castleRights : g_castleRights >> 2;
			if (cr & 1)
				if(g_board[fr + 1] & colorEmpty && g_board[fr + 2] & colorEmpty)
					GenerateMove(moves,fr,fr + 2,moveflagCastleKing);
			if (cr & 2)
				if(g_board[fr - 1] & colorEmpty && g_board[fr - 2] & colorEmpty && g_board[fr - 3] & colorEmpty)
					GenerateMove(moves,fr,fr - 2,moveflagCastleQueen);
		}
	}
}
return moves;
}

function GeneratePwnMoves(moves,fr,to,add,flag){
if(((boardCheck[to] & g_lastCastle) == g_lastCastle) && g_lastCastle & maskCastle)
	g_inCheck = true;
else if(add){
	var y = to >> 4;
	if((y == 4) || (y == 11)){
		GenerateMove(moves,fr,to,moveflagPromoteQueen);
		GenerateMove(moves,fr,to,moveflagPromoteRook);
		GenerateMove(moves,fr,to,moveflagPromoteBishop);
		GenerateMove(moves,fr,to,moveflagPromoteKnight);
	}else 
		GenerateMove(moves,fr,to,flag);
}
}

function GenerateUniMoves(moves,fr,dir,count){
for(var n = 0;n < dir.length;n++){
	var to = fr;
	var c = count;
	while(c--){
		to += dir[n];
		if(g_board[to] & colorEmpty)
			GenerateMove(moves,fr,to);
		else if(g_board[to] & enColor){
			GenerateMove(moves,fr,to);
			break;
		}else
			break;
	}
}
}

function MakeMove(move){
var fr = move & 0xFF;
var to = (move >> 8) & 0xFF;
var flags = move & 0xFF0000;
var piecefr = g_board[fr];
var piece = piecefr & 0xf;
var capi = to;
g_captured = g_board[to];
g_lastCastle = (move & maskCastle) | (piecefr & maskColor);
if(flags & moveflagCastleKing){
	g_board[to - 1] =  g_board[to + 1];
	g_board[to + 1] = colorEmpty;
}else if(flags & moveflagCastleQueen){
	g_board[to + 1] = g_board[to - 2];
	g_board[to - 2] = colorEmpty;
}else if(flags & moveflagPassing){
	capi = whiteTurn ? to + 16 : to - 16;
	g_captured = g_board[capi];
	g_board[capi]=colorEmpty;
}
undoStack.push(new cUndo());
g_passing = 0;
if(g_captured & 0xF)
	g_move50 = 0;
else if((piece & 7) == piecePawn) {
	if(to == (fr + 32))g_passing = (fr + 16);
	if(to == (fr - 32))g_passing = (fr - 16);
	g_move50 = 0;
}else
	g_move50++;
if (flags & moveflagPromotion){
	var newPiece = piecefr & (~0x7);
	if (flags & moveflagPromoteKnight)
		newPiece |= pieceKnight;
	else if (flags & moveflagPromoteQueen)
		newPiece |= pieceQueen;
	else if (flags & moveflagPromoteBishop)
		newPiece |= pieceBishop;
	else
		newPiece |= pieceRook;
	g_board[to] = newPiece;
}else
	g_board[to] = g_board[fr];
g_board[fr] = colorEmpty;
g_castleRights &= boardCastle[fr] & boardCastle[to];
whiteTurn ^= 1;
g_moveNumber++;
}

function UnmakeMove(move){
var fr = move & 0xFF;
var to = (move >> 8) & 0xFF;
var flags = move & 0xFF0000;
var piece = g_board[to];
var capi = to;
var undo = undoStack[undoStack.length-1];
undoStack.pop();
g_passing = undo.passing;
g_castleRights = undo.castle;
g_move50 = undo.move50;
g_lastCastle = undo.lastCastle;
var captured=undo.captured;
if (flags & moveflagCastleKing) {
	g_board[to + 1] = g_board[to - 1];
	g_board[to - 1] = colorEmpty;
}else if (flags & moveflagCastleQueen){
	g_board[to - 2] = g_board[to + 1];
	g_board[to + 1] = colorEmpty;
}
if (flags & moveflagPromotion) {
	piece = (g_board[to] & (~0x7)) | piecePawn;
	g_board[fr] = piece;
}else g_board[fr] = g_board[to];
if(flags & moveflagPassing){
	capi = whiteTurn ? to - 16 : to + 16;
	g_board[to] = colorEmpty;
}
g_board[capi] = captured;
whiteTurn ^= 1;
g_moveNumber--;
}

var bsIn = -1;
var bsFm = '';
var bsPv = '';

function GetScore(mu,depth,depthL,alpha,beta){
var myMobility = adjMobility;
var n = mu.length;
var myMoves = n;
var alphaDe = 0;
var alphaFm = '';
var alphaPv = '';
while(n--){
	if(!(++g_totalNodes & 0x1fff))	
		g_stop = ((depthL > 1) && ((g_timeout && (Date.now() - g_startTime > g_timeout)) ||  (g_nodeout && (g_totalNodes > g_nodeout))));
	var cm = mu[n];
	MakeMove(cm);
	g_depth = 0;
	g_pv = '';
	var me = GenerateAllMoves(whiteTurn);
	var osScore = myMobility - adjMobility;
	if(g_inCheck){
		myMoves--;
		osScore = -0xffff;
	}else if(g_move50 > 99)
		osScore = 0;
	else if(depth < depthL)
		osScore = -GetScore(me,depth + 1,depthL,-beta,-alpha);
	UnmakeMove(cm);
	if(g_stop)return -0xffff;
	if(alpha < osScore){
		alpha = osScore;
		alphaFm = FormatMove(cm);
		alphaPv = alphaFm + ' ' + g_pv;
		alphaDe = g_depth + 1;
		if(depth == 1){
			if(osScore > 0xf000)
				g_scoreFm = 'mate ' + ((0xffff - osScore) >> 1);
			else if(osScore < -0xf000)
				g_scoreFm = 'mate ' + ((-0xfffe - osScore) >> 1);
			else
				g_scoreFm = 'cp ' + (osScore >> 2);
			bsIn = n;
			bsFm = alphaFm;
			bsPv = alphaPv;
			var time = Date.now() - g_startTime;
			var nps = Math.floor((g_totalNodes / time) * 1000);
			postMessage('info currmove ' + bsFm + ' currmovenumber ' + n + ' nodes ' + g_totalNodes + ' time ' + time + ' nps ' + nps + ' depth ' + depthL + ' seldepth ' + alphaDe + ' score ' + g_scoreFm + ' pv ' + bsPv);
		}
	}
	if(alpha >= beta)break;
}
if(!myMoves){
	GenerateAllMoves(whiteTurn ^ 1);
	if(!g_inCheck)alpha = 0;else alpha = -0xffff + depth;
}
g_depth = alphaDe;
g_pv = alphaPv;
return alpha;
}

function Search(depth,time,nodes){
var mu = GenerateAllMoves(whiteTurn);
var depthL = depth ? depth : 1;
g_stop = false;
g_totalNodes = 0;
g_timeout = time;
g_nodeout = nodes;
do{
	bsIn =  mu.length - 1;
	var os = GetScore(mu,1,depthL++,-0xffff,0xffff);
	mu.push(mu.splice(bsIn,1));
}while((!depth || (depth > depthL)) && !g_stop);
var time = Date.now() - g_startTime;
var nps = Math.floor((g_totalNodes / time) * 1000);
var ponder = bsPv.split(' ');
var pm = ponder.length > 1 ? ' ponder ' + ponder[1] : '';
postMessage('info nodes ' + g_totalNodes + ' time ' + time + ' nps ' + nps);
postMessage('bestmove ' + bsFm + pm);
}

var cUndo = function(){
this.captured = g_captured;
this.passing = g_passing;
this.castle = g_castleRights;
this.move50 = g_move50;
this.lastCastle = g_lastCastle;
}

Initialize();

function GetNumber(msg,re,def){
var r = re.exec(msg);
return r ? r[1] | 0 : def;
}

onmessage = function(e){
(/^(.*?)\n?$/).exec(e.data);
var msg = RegExp.$1;
if(msg == 'uci'){
	postMessage('id name Rapshort ' + version);
	postMessage('id author Thibor Raven');
	postMessage('uciok');
}else if (msg == 'isready')
	postMessage('readyok');
else if ((/^position (?:(startpos)|fen (.*?))\s*(?:moves\s*(.*))?$/).exec(msg)){
	InitializeFromFen((RegExp.$1 == 'startpos') ? '' : RegExp.$2);
	if(RegExp.$3){
		var m =  (RegExp.$3).split(' ');
		for(var i = 0;i < m.length;i++)
			MakeMove(GetMoveFromString(m[i]));
	}
}else if((/^go /).exec(msg)){
	g_startTime = Date.now();
	var t = GetNumber(msg,/movetime (\d+)/,0);
	var d = GetNumber(msg,/depth (\d+)/,0);
	var n = GetNumber(msg,/nodes (\d+)/,0);
	if(!t && !d && !n){
		t = whiteTurn ? GetNumber(msg,/wtime (\d+)/,0) : GetNumber(msg,/btime (\d+)/,0);
		var mg = GetNumber(msg,/movestogo (\d+)/,32);
		t = Math.floor(t / mg);
		if (t < 0x40){
			t = 0;
			d = 1;
		}
	}
	Search(d,t,n);
}
}