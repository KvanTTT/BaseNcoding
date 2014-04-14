var alphabets = {}

alphabets['32'] = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ234567';
alphabets['64'] = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/';
alphabets['85'] = '!\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstu';
alphabets['91'] = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&()*+,./:;<=>?@[]^_`{|}~"';
alphabets['max'] = '\u0021\u0022\u0023\u0024\u0025\u0026\u005c\u0027\u0028\u0029\u002a\u002b\u002c\u002d\u002e\u002f\u0030\u0031\u0032\u0033\u0034\u0035\u0036\u0037\u0038\u0039\u003a\u003b\u003c\u003d\u003e\u003f\u0040\u0041\u0042\u0043\u0044\u0045\u0046\u0047\u0048\u0049\u004a\u004b\u004c\u004d\u004e\u004f\u0050\u0051\u0052\u0053\u0054\u0055\u0056\u0057\u0058\u0059\u005a\u005b\u005c\u005d\u005e\u005f\u0060\u0061\u0062\u0063\u0064\u0065\u0066\u0067\u0068\u0069\u006a\u006b\u006c\u006d\u006e\u006f\u0070\u0071\u0072\u0073\u0074\u0075\u0076\u0077\u0078\u0079\u007a\u007b\u007c\u007d\u007e\u00a1\u00a2\u00a3\u00a4\u00a5\u00a6\u00a7\u00a8\u00a9\u00aa\u00ab\u00ac\u00ad\u00ae\u00af\u00b0\u00b1\u00b2\u00b3\u00b4\u00b5\u00b6\u00b7\u00b8\u00b9\u00ba\u00bb\u00bc\u00bd\u00be\u00bf\u00c0\u00c1\u00c2\u00c3\u00c4\u00c5\u00c6\u00c7\u00c8\u00c9\u00ca\u00cb\u00cc\u00cd\u00ce\u00cf\u00d0\u00d1\u00d2\u00d3\u00d4\u00d5\u00d6\u00d7\u00d8\u00d9\u00da\u00db\u00dc\u00dd\u00de\u00df\u00e0\u00e1\u00e2\u00e3\u00e4\u00e5\u00e6\u00e7\u00e8\u00e9\u00ea\u00eb\u00ec\u00ed\u00ee\u00ef\u00f0\u00f1\u00f2\u00f3\u00f4\u00f5\u00f6\u00f7\u00f8\u00f9\u00fa\u00fb\u00fc\u00fd\u00fe\u00ff\u0100\u0101\u0102\u0103\u0104\u0105\u0106\u0107\u0108\u0109\u010a\u010b\u010c\u010d\u010e\u010f\u0110\u0111\u0112\u0113\u0114\u0115\u0116\u0117\u0118\u0119\u011a\u011b\u011c\u011d\u011e\u011f\u0120\u0121\u0122\u0123\u0124\u0125\u0126\u0127\u0128\u0129\u012a\u012b\u012c\u012d\u012e\u012f\u0130\u0131\u0132\u0133\u0134\u0135\u0136\u0137\u0138\u0139\u013a\u013b\u013c\u013d\u013e\u013f\u0140\u0141\u0142\u0143\u0144\u0145\u0146\u0147\u0148\u0149\u014a\u014b\u014c\u014d\u014e\u014f\u0150\u0151\u0152\u0153\u0154\u0155\u0156\u0157\u0158\u0159\u015a\u015b\u015c\u015d\u015e\u015f\u0160\u0161\u0162\u0163\u0164\u0165\u0166\u0167\u0168\u0169\u016a\u016b\u016c\u016d\u016e\u016f\u0170\u0171\u0172\u0173\u0174\u0175\u0176\u0177\u0178\u0179\u017a\u017b\u017c\u017d\u017e\u017f\u0180\u0181\u0182\u0183\u0184\u0185\u0186\u0187\u0188\u0189\u018a\u018b\u018c\u018d\u018e\u018f\u0190\u0191\u0192\u0193\u0194\u0195\u0196\u0197\u0198\u0199\u019a\u019b\u019c\u019d\u019e\u019f\u01a0\u01a1\u01a2\u01a3\u01a4\u01a5\u01a6\u01a7\u01a8\u01a9\u01aa\u01ab\u01ac\u01ad\u01ae\u01af\u01b0\u01b1\u01b2\u01b3\u01b4\u01b5\u01b6\u01b7\u01b8\u01b9\u01ba\u01bb\u01bc\u01bd\u01be\u01bf\u01c0\u01c1\u01c2\u01c3\u01c4\u01c5\u01c6\u01c7\u01c8\u01c9\u01ca\u01cb\u01cc\u01cd\u01ce\u01cf\u01d0\u01d1\u01d2\u01d3\u01d4\u01d5\u01d6\u01d7\u01d8\u01d9\u01da\u01db\u01dc\u01dd\u01de\u01df\u01e0\u01e1\u01e2\u01e3\u01e4\u01e5\u01e6\u01e7\u01e8\u01e9\u01ea\u01eb\u01ec\u01ed\u01ee\u01ef\u01f0\u01f1\u01f2\u01f3\u01f4\u01f5\u01f6\u01f7\u01f8\u01f9\u01fa\u01fb\u01fc\u01fd\u01fe\u01ff\u0200\u0201\u0202\u0203\u0204\u0205\u0206\u0207\u0208\u0209\u020a\u020b\u020c\u020d\u020e\u020f\u0210\u0211\u0212\u0213\u0214\u0215\u0216\u0217\u0218\u0219\u021a\u021b\u021c\u021d\u021e\u021f\u0220\u0221\u0222\u0223\u0224\u0225\u0226\u0227\u0228\u0229\u022a\u022b\u022c\u022d\u022e\u022f\u0230\u0231\u0232\u0233\u0234\u0235\u0236\u0237\u0238\u0239\u023a\u023b\u023c\u023d\u023e\u023f\u0240\u0241\u0242\u0243\u0244\u0245\u0246\u0247\u0248\u0249\u024a\u024b\u024c\u024d\u024e\u024f\u0250\u0251\u0252\u0253\u0254\u0255\u0256\u0257\u0258\u0259\u025a\u025b\u025c\u025d\u025e\u025f\u0260\u0261\u0262\u0263\u0264\u0265\u0266\u0267\u0268\u0269\u026a\u026b\u026c\u026d\u026e\u026f\u0270\u0271\u0272\u0273\u0274\u0275\u0276\u0277\u0278\u0279\u027a\u027b\u027c\u027d\u027e\u027f\u0280\u0281\u0282\u0283\u0284\u0285\u0286\u0287\u0288\u0289\u028a\u028b\u028c\u028d\u028e\u028f\u0290\u0291\u0292\u0293\u0294\u0295\u0296\u0297\u0298\u0299\u029a\u029b\u029c\u029d\u029e\u029f\u02a0\u02a1\u02a2\u02a3\u02a4\u02a5\u02a6\u02a7\u02a8\u02a9\u02aa\u02ab\u02ac\u02ad\u02ae\u02af\u02b0\u02b1\u02b2\u02b3\u02b4\u02b5\u02b6\u02b7\u02b8\u02b9\u02ba\u02bb\u02bc\u02bd\u02be\u02bf\u02c0\u02c1\u02c2\u02c3\u02c4\u02c5\u02c6\u02c7\u02c8\u02c9\u02ca\u02cb\u02cc\u02cd\u02ce\u02cf\u02d0\u02d1\u02d2\u02d3\u02d4\u02d5\u02d6\u02d7\u02d8\u02d9\u02da\u02db\u02dc\u02dd\u02de\u02df\u02e0\u02e1\u02e2\u02e3\u02e4\u02e5\u02e6\u02e7\u02e8\u02e9\u02ea\u02eb\u02ec\u02ed\u02ee\u02ef\u02f0\u02f1\u02f2\u02f3\u02f4\u02f5\u02f6\u02f7\u02f8\u02f9\u02fa\u02fb\u02fc\u02fd\u02fe\u02ff\u0300\u0301\u0302\u0303\u0304\u0305\u0306\u0307\u0308\u0309\u030a\u030b\u030c\u030d\u030e\u030f\u0310\u0311\u0312\u0313\u0314\u0315\u0316\u0317\u0318\u0319\u031a\u031b\u031c\u031d\u031e\u031f\u0320\u0321\u0322\u0323\u0324\u0325\u0326\u0327\u0328\u0329\u032a\u032b\u032c\u032d\u032e\u032f\u0330\u0331\u0332\u0333\u0334\u0335\u0336\u0337\u0338\u0339\u033a\u033b\u033c\u033d\u033e\u033f\u0340\u0341\u0342\u0343\u0344\u0345\u0346\u0347\u0348\u0349\u034a\u034b\u034c\u034d\u034e\u034f\u0350\u0351\u0352\u0353\u0354\u0355\u0356\u0357\u0358\u0359\u035a\u035b\u035c\u035d\u035e\u035f\u0360\u0361\u0362\u0363\u0364\u0365\u0366\u0367\u0368\u0369\u036a\u036b\u036c\u036d\u036e\u036f\u0374\u0375\u037a\u037b\u037c\u037d\u037e\u0384\u0385\u0386\u0387\u0388\u0389\u038a\u038b\u038c\u038d\u038e\u038f\u0390\u0391\u0392\u0393\u0394\u0395\u0396\u0397\u0398\u0399\u039a\u039b\u039c\u039d\u039e\u039f\u03a0\u03a1\u03a2\u03a3\u03a4\u03a5\u03a6\u03a7\u03a8\u03a9\u03aa\u03ab\u03ac\u03ad\u03ae\u03af\u03b0\u03b1\u03b2\u03b3\u03b4\u03b5\u03b6\u03b7\u03b8\u03b9\u03ba\u03bb\u03bc\u03bd\u03be\u03bf\u03c0\u03c1\u03c2\u03c3\u03c4\u03c5\u03c6\u03c7\u03c8\u03c9\u03ca\u03cb\u03cc\u03cd\u03ce\u03d0\u03d1\u03d2\u03d3\u03d4\u03d5\u03d6\u03d7\u03d8\u03d9\u03da\u03db\u03dc\u03dd\u03de\u03df\u03e0\u03e1\u03e2\u03e3\u03e4\u03e5\u03e6\u03e7\u03e8\u03e9\u03ea\u03eb\u03ec\u03ed\u03ee\u03ef\u03f0\u03f1\u03f2\u03f3\u03f4\u03f5\u03f6\u03f7\u03f8\u03f9\u03fa\u03fb\u03fc\u03fd\u03fe\u03ff\u0400\u0401\u0402\u0403\u0404\u0405\u0406\u0407\u0408\u0409\u040a\u040b\u040c\u040d\u040e\u040f\u0410\u0411\u0412\u0413\u0414\u0415\u0416\u0417\u0418\u0419\u041a\u041b\u041c\u041d\u041e\u041f\u0420\u0421\u0422\u0423\u0424\u0425\u0426\u0427\u0428\u0429\u042a\u042b\u042c\u042d\u042e\u042f\u0430\u0431\u0432\u0433\u0434\u0435\u0436\u0437\u0438\u0439\u043a\u043b\u043c\u043d\u043e\u043f\u0440\u0441\u0442\u0443\u0444\u0445\u0446\u0447\u0448\u0449\u044a\u044b\u044c\u044d\u044e\u044f\u0450\u0451\u0452\u0453\u0454\u0455\u0456\u0457\u0458\u0459\u045a\u045b\u045c\u045d\u045e\u045f\u0460\u0461\u0462\u0463\u0464\u0465\u0466\u0467\u0468\u0469\u046a\u046b\u046c\u046d\u046e\u046f\u0470\u0471\u0472\u0473\u0474\u0475\u0476\u0477\u0478\u0479\u047a\u047b\u047c\u047d\u047e\u047f\u0480';

function BaseN(alphabet, blockMaxBitsCount, reverseOrder) {
	this.alphabet = alphabet;
	this.charsCount = alphabet.length;
	this.bigCharsCount = new BigInteger(alphabet.length.toString());
    var bitsCharsCount = getOptimalBitsCount(this.charsCount, blockMaxBitsCount, 2);
    this.blockBitsCount = bitsCharsCount.bitsCount;
    this.blockCharsCount = bitsCharsCount.charsCountInBits;
	this.reverseOrder = reverseOrder;
    this.powN = [];
    var pow = new BigInteger('1');
    for (var i = 0; i < this.blockCharsCount - 1; i++) {
        this.powN[this.blockCharsCount - 1 - i] = pow;
        pow = pow.multiply(this.bigCharsCount);
    }
    this.powN[0] = pow;
	
	this.two_in_power_n = [];
	var a = 2;
	for (var i = 0; i < 8; i++) {
		this.two_in_power_n[i] = new BigInteger((a - 1).toString());
		a *= 2;
    }
	
	this.invAlphabet = [];
	for (var i = 0; i < this.charsCount; i++)
		this.invAlphabet[this.alphabet[i]] = i;
}

BaseN.prototype.encodeString = function(str) {
	return this.encodeBytes(strToUtf8Bytes(str));
}

BaseN.prototype.encodeBytes = function(data)  {
	var mainBitsLength = (Math.floor(data.length * 8 / this.blockBitsCount)) * this.blockBitsCount;
	var tailBitsLength = data.length * 8 - mainBitsLength;
	var globalBitsLength = mainBitsLength + tailBitsLength;
	var mainCharsCount = Math.floor(mainBitsLength * this.blockCharsCount / this.blockBitsCount);
	var tailCharsCount = Math.floor((tailBitsLength * this.blockCharsCount + this.blockBitsCount - 1) / this.blockBitsCount);
	var globalCharsCount = mainCharsCount + tailCharsCount;
	var iterCount = Math.floor(mainCharsCount / this.blockCharsCount);

	var result = [];

	for (var i = 0; i < iterCount; i++) {
		this.encodeBlock(data, result, i);
	}
	if (tailBitsLength != 0) {
		var bits = this.getBitsN(data, mainBitsLength, tailBitsLength);
		this.encodeBlock2(result, mainCharsCount, tailCharsCount, bits);
	}

	return result.join("");
}
	
BaseN.prototype.encodeBlock = function(src, dst, ind) {
	var charInd = ind * this.blockCharsCount;
	var bitInd = ind * this.blockBitsCount;
	var bits = this.getBitsN(src, bitInd, this.blockBitsCount);
	this.encodeBlock2(dst, charInd, this.blockCharsCount, bits);
}

BaseN.prototype.encodeBlock2 = function(chars, ind, count, block) {
	for (var i = 0; i < count; i++)
	{
		chars[ind + (!this.reverseOrder ? i : count - 1 - i)] = this.alphabet[block.modInt(this.charsCount)];
		block = block.divide(this.bigCharsCount);
	}
}

BaseN.prototype.getBitsN = function(data, bitPos, bitsCount) {
	var result = new BigInteger('0');

	var curBitPos = bitPos;
	var curBytePos = Math.floor(bitPos / 8);
	var curBitInBytePos = bitPos % 8;
	var xLength = Math.min(bitsCount, 8 - curBitInBytePos);
	
	if (xLength != 0)
	{
		var bigInt = new BigInteger(data[curBytePos].toString());
		result = bigInt.shiftRight(8 - xLength - curBitInBytePos).and(this.two_in_power_n[7 - curBitInBytePos]).shiftLeft(bitsCount - xLength);

		curBytePos += Math.floor((curBitInBytePos + xLength) / 8);
		curBitInBytePos = (curBitInBytePos + xLength) % 8;
		curBitPos += xLength;

		var x2Length = bitsCount - xLength;
		if (x2Length > 8)
			x2Length = 8;

		while (x2Length > 0)
		{
			xLength += x2Length;
			result = result.or((new BigInteger((data[curBytePos] >> 8 - x2Length).toString())).shiftLeft(bitsCount - xLength));

			curBytePos += Math.floor((curBitInBytePos + x2Length) / 8);
			curBitInBytePos = (curBitInBytePos + x2Length) % 8;
			curBitPos += x2Length;

			x2Length = bitsCount - xLength;
			if (x2Length > 8)
				x2Length = 8;
		}
	}

	return result;
}

BaseN.prototype.decodeToString = function(str) {
	return bytesToUtf8Str(this.decodeToBytes(str));
}

BaseN.prototype.decodeToBytes = function(data) {
	var globalBitsLength = Math.floor((Math.floor((data.length - 1) * this.blockBitsCount / this.blockCharsCount) + 8) / 8) * 8;
	var mainBitsLength = Math.floor(globalBitsLength / this.blockBitsCount) * this.blockBitsCount;
	var tailBitsLength = globalBitsLength - mainBitsLength;
	var mainCharsCount = Math.floor(mainBitsLength * this.blockCharsCount / this.blockBitsCount);
	var tailCharsCount = Math.floor((tailBitsLength * this.blockCharsCount + this.blockBitsCount - 1) / this.blockBitsCount);
	var tailBits = this.decodeBlock2(data, mainCharsCount, tailCharsCount);
	if (tailBits >> tailBitsLength != 0)
	{
		globalBitsLength += 8;
		mainBitsLength = Math.floor(globalBitsLength / this.blockBitsCount) * this.blockBitsCount;
		tailBitsLength = globalBitsLength - mainBitsLength;
		mainCharsCount = Math.floor(mainBitsLength * this.blockCharsCount / this.blockBitsCount);
		tailCharsCount = Math.floor((tailBitsLength * this.blockCharsCount + this.blockBitsCount - 1) / this.blockBitsCount);
	}
	var iterCount = Math.floor(mainCharsCount / this.blockCharsCount);

	var result = [];
	for (var i = 0; i < iterCount; i++) {
		this.decodeBlock(data, result, i);
	}
	if (tailCharsCount != 0) {
		var bits = this.decodeBlock2(data, mainCharsCount, tailCharsCount);
		this.addBitsN(result, bits, mainBitsLength, tailBitsLength);
	}
	
	return result;
}

BaseN.prototype.decodeBlock = function(src, dst, ind) {
	var charInd = ind * this.blockCharsCount;
	var bitInd = ind * this.blockBitsCount;
	var bits = this.decodeBlock2(src, charInd, this.blockCharsCount);
	this.addBitsN(dst, bits, bitInd, this.blockBitsCount);
}

BaseN.prototype.decodeBlock2 = function(data, ind, count) {
	var result = new BigInteger('0');
	for (var i = 0; i < count; i++) {
		var bigInt = new BigInteger(this.invAlphabet[data[ind + (!this.reverseOrder ? i : count - 1 - i)]].toString());
		result = result.add(bigInt.multiply(this.powN[this.blockCharsCount - 1 - i]));
	}
	return result;
}

BaseN.prototype.addBitsN = function(data, value, bitPos, bitsCount) {
	var curBitPos = bitPos;
	var curBytePos = Math.floor(bitPos / 8);
	var curBitInBytePos = bitPos % 8;

	var xLength = Math.min(bitsCount, 8 - curBitInBytePos);
	if (xLength != 0) {
		var x1 = value.shiftRight(bitsCount + curBitInBytePos - 8).and(this.two_in_power_n[7 - curBitInBytePos]).byteValue() & 0xFF;
		data[curBytePos] |= x1;

		curBytePos += Math.floor((curBitInBytePos + xLength) / 8);
		curBitInBytePos = (curBitInBytePos + xLength) % 8;
		curBitPos += xLength;

		var x2Length = bitsCount - xLength;
		if (x2Length > 8)
			x2Length = 8;

		while (x2Length > 0) {
			xLength += x2Length;
			var x2 = value.shiftRight(bitsCount - xLength).shiftLeft(8 - x2Length).byteValue() & 0xFF;
			data[curBytePos] |= x2;

			curBytePos += Math.floor((curBitInBytePos + x2Length) / 8);
			curBitInBytePos = (curBitInBytePos + x2Length) % 8;
			curBitPos += x2Length;

			x2Length = bitsCount - xLength;
			if (x2Length > 8)
				x2Length = 8;
		}
	}
}

function BitsCharsCount(bitsCount, charsCountInBits) {
    this.bitsCount = bitsCount;
    this.charsCountInBits = charsCountInBits;
}

function getOptimalBitsCount(charsCount, maxBitsCount, radix) {
	var bitsCount = 0;
	var charsCountInBits = 0;
	var n1 = logBaseN(charsCount, radix);
	var charsCountLog = Math.log(radix) / Math.log(charsCount);
	var maxRatio = 0;

	for (var n = n1; n <= maxBitsCount; n++)
	{
		var l1 = Math.ceil(n * charsCountLog);
		var ratio = n / l1;
		if (ratio > maxRatio)
		{
			maxRatio = ratio;
			bitsCount = n;
			charsCountInBits = l1;
		}
	}

	return new BitsCharsCount(bitsCount, charsCountInBits);
}

function logBaseN(x, n) {
    var r = 0;
	while ((x = Math.floor(x / n)) !== 0)
		r++;
	return r;
}

function strToUtf8Bytes(str) {
    var utf8 = [];
    for (var i=0; i < str.length; i++) {
        var charcode = str.charCodeAt(i);
        if (charcode < 0x80) utf8.push(charcode);
        else if (charcode < 0x800) {
            utf8.push(0xc0 | (charcode >> 6), 
                      0x80 | (charcode & 0x3f));
        }
        else if (charcode < 0xd800 || charcode >= 0xe000) {
            utf8.push(0xe0 | (charcode >> 12), 
                      0x80 | ((charcode>>6) & 0x3f), 
                      0x80 | (charcode & 0x3f));
        }
        // surrogate pair
        else {
            i++;
            // UTF-16 encodes 0x10000-0x10FFFF by
            // subtracting 0x10000 and splitting the
            // 20 bits of 0x0-0xFFFFF into two halves
            charcode = 0x10000 + (((charcode & 0x3ff)<<10)
                      | (str.charCodeAt(i) & 0x3ff));
            utf8.push(0xf0 | (charcode >>18), 
                      0x80 | ((charcode>>12) & 0x3f), 
                      0x80 | ((charcode>>6) & 0x3f), 
                      0x80 | (charcode & 0x3f));
        }
    }
    return utf8;
}

function bytesToUtf8Str(bytes) {
    var out, i, len, c;
    var char2, char3;

    out = "";
    len = bytes.length;
    i = 0;
    while(i < len) {
		c = bytes[i++];
		switch(c >> 4)
		{ 
		  case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
			// 0xxxxxxx
			out += String.fromCharCode(c);
			break;
		  case 12: case 13:
			// 110x xxxx   10xx xxxx
			char2 = bytes[i++];
			out += String.fromCharCode(((c & 0x1F) << 6) | (char2 & 0x3F));
			break;
		  case 14:
			// 1110 xxxx  10xx xxxx  10xx xxxx
			char2 = bytes[i++];
			char3 = bytes[i++];
			out += String.fromCharCode(((c & 0x0F) << 12) |
						   ((char2 & 0x3F) << 6) |
						   ((char3 & 0x3F) << 0));
			break;
		}
    }

    return out;
}
