var baseN;

$(function() {
	rebuildBase();

    $('#base').spinner({
		min: 2,
		max: alphabets['max'].length,
		step: 1,
		start: 85,
		change: function(event, ui) {
			var alphabet = alphabets['max'].substr(0, $("#base").spinner("value"));
			$('#alphabet').val(alphabet);
			$('#base').val(alphabet.length);
			rebuildBase();
		}
    });

	$("#base").bind('spin', function (event, ui) {
		var alphabet = alphabets['max'].substr(0, ui.value);
		$('#alphabet').val(alphabet);
		$('#base').val(alphabet.length);
		rebuildBase();
	});

	$('#maxBitsCount').spinner({
		min: 2,
		max: 512,
		step: 1,
		start: 64,
		change: function(event, ui) {
			rebuildBase();
		}
    });

	$("#maxBitsCount").bind('spin', function (event, ui) {
		rebuildBase();
	});

	$('#btnEncode').addClass('active');
	$('#btnEncodeDecode .btn').click(function() {
		if (this.id === 'btnEncode') {
			$('#btnDecode').removeClass('active');
		} else {
			$('#btnEncode').removeClass('active');
		}
	});

	$('.gen_alphabet').click(function() {
		var alphabet = alphabets[$(this).val()];
		$('#alphabet').val(alphabet);
		$('#base').val(alphabet.length);
		rebuildBase();
	});

	$('#alphabet').on('change keyup paste', function() {
		$('#base').val($('#alphabet').val().length);
		rebuildBase();
	});

	$('#convert').click(function() {
		try {
			var alphabet = $('#alphabet').val();
			for (var i = 0; i < alphabet.length; i++) {
				for (var j = i + 1; j < alphabet.length; j++) {
					if (alphabet[i] === alphabet[j]) {
						throw new Error("Alphabet should contains distinct chars");
					}
				}
			}
			baseN = new BaseN(alphabet, parseInt($('#maxBitsCount').val()), $('#btnReverseOrder').hasClass('active'), $('#btnOneBigNumber').hasClass('active'));

			var input = $('#input').val();
			var converted;
			if ($('#btnEncode').hasClass('active')) {
				converted = baseN.encodeString(input);
			} else {
				converted = baseN.decodeToString(input);
			}

			$('#output').val(converted);
			printBlockSize();
		}
		catch (er) {
			alert(er.message);
		}
	});
});

function rebuildBase() {
	baseN = new BaseN($('#alphabet').val(), parseInt($('#maxBitsCount').val()), $('#btnReverseOrder').hasClass('active'), $('#btnOneBigNumber').hasClass('active'));
	printBlockSize();
	$('#output').val('');
}

function printBlockSize() {
	$('#info').html('<strong>Block size: ' + baseN.blockBitsCount + ' bits per ' + baseN.blockCharsCount + ' chars. Redundancy: ' + ((baseN.blockCharsCount * 8) / baseN.blockBitsCount).toFixed(4) + '</strong>');
}