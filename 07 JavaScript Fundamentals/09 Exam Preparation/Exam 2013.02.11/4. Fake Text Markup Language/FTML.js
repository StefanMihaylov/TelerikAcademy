function solve(inputs) {

    function reverse(text) {
        var result = '';
        for (var i = text.length - 1; i >= 0; i--) {
            result += text[i];
        }
        return result;
    }

    function toggle(text) {
        var result = '';
        for (var i = 0; i < text.length; i++) {
            if (text[i] === text[i].toLowerCase()) {
                result += text[i].toUpperCase();
            }
            else {
                result += text[i].toLowerCase();
            }
        }
        return result;
    }

    var result = [];

    for (var i = 1; i < inputs.length; i++) {
        var row = inputs[i];        

        var isInTag = false;
        var isInClosingTag = false;
        var text = '';
        var tag = '';
        var lastRecord;

        for (var j = 0; j < row.length; j++) {
            var symbol = row[j];

            if (isInTag && symbol === '/') {
                isInClosingTag = true;
                continue;
            }

            if (symbol === '<') {
                isInTag = true;
                if (result.length === 0) {
                    result.push({
                        tag: '',
                        text: text,
                    });
                }
                else {
                    lastRecord = result.pop();
                    lastRecord.text += text;
                    result.push(lastRecord);
                }
                text = '';
                continue;
            }         

            if (symbol === '>') {
                isInTag = false;

                if (!isInClosingTag) {
                    result.push({
                        tag: tag,
                        text: '',
                    });
                    tag = '';
                }
                else {
                    isInClosingTag = false;
                    lastRecord = result.pop();

                    switch (tag) {
                        case 'upper': currentText = lastRecord.text.toUpperCase(); break;
                        case 'lower': currentText = lastRecord.text.toLowerCase(); break;
                        case 'toggle': currentText = toggle(lastRecord.text); break;
                        case 'del': currentText = ''; break;
                        case 'rev': currentText = reverse(lastRecord.text); break;
                    }
                    lastRecord = result.pop();
                    lastRecord.text += currentText;
                    result.push(lastRecord);
                    tag = ''; 
                }
                
                //for (var ind = 0; ind < result.length; ind++) {
                //    console.log(result[ind].tag + ' - ' + result[ind].text);
                //}
                

                continue;
            }

            if (isInTag) {
                tag += symbol;
            }
            else {
                text += symbol;
            }            
        }

        lastRecord = result.pop();
        lastRecord.text += text + '\n';
        result.push(lastRecord);

        //console.log(result);       
    }

    return result[0].text.trim();
}

var test1 = [
'2',
'So<rev><upper>saw</upper> txet em</rev>',
'<lower><upper>here</upper></lower>'
];
var test2 = [
'3',
'<toggle><rev>ERa</rev></toggle> you',
'<rev>noc</rev><lower>FUSED</lower>',
'<rev>?<rev>already </rev></rev>'
];
var test3 = [
'1',
'So<rev><upper>saw</upper> txet em</rev>'
];
var test4 = [
'3',
'<del><rev></rev></del><upper>Shalalalalalalalalallalalalalalallallalalalalalala</upper>',
'sha',
'lala',
];
var test5 = [
'9', 
'If youre a <rev><rev>developer</rev></rev> you probably dont need to read this part.', 
'Otherwise has stopped working messages are <rev><upper>triggered</upper></rev> by what is called an unhandled exception.', 
'<upper>Exceptions</upper> <upper>are <lower>ways<del>ways</del></lower> for programs</upper>', 
'(and parts of them) to', 
'report', 
'errors. <rev>For', 
'example</rev> no more <rev>hard-disk</rev> space no access rights not enough RAM<del> no internet connection</del>', 
'are typical problems reported through <upper>exceptions</upper>. When a part of a program encounters such a', 
'problem it <upper>throws</upper> an exception'
];

console.log('----Result: = ' + solve(test1));
console.log('----Result: = ' + solve(test2));
console.log('----Result: = ' + solve(test3));
console.log('----Result: = ' + solve(test4));
console.log('----Result: = ' + solve(test5));