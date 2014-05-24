function solve(inputs) {
    var N = parseInt(inputs[0]);
    var dictionary = [];
    for (var i = 0; i < N; i++) {
        var separatedKeys = inputs[1 + i].split('-');
        var value = separatedKeys[1].trim();
        if (value === 'true') {
            value = true;
        }
        else if (value === 'false') {
            value = false;
        }
        else if (value.indexOf(';') >= 0) {
            value = value.split(';');
        }

        dictionary[separatedKeys[0]] = value;
    }

    //console.log(dictionary);
    var M = parseInt(inputs[1 + N]);

    var result = '';
    var inTag = false;
    var inEndTag = false;
    var firstEscapeON = false;
    var inEscape = false;
    var templates = [];
    var tag = '';
    var text = '';
    var inTemplateTag = false;
    var templateName = '';
    var templateAtrribute = '';
    var contents = '';
    var inRender = false;
    var inModel = false;


    for (i = 0; i < M - 2 - N; i++) {
        var row = inputs[i + 2 + N];
       // console.log(row);
        for (var j = 0; j < row.length; j++) {
            var symbol = row[j];

            if (symbol === '<' && !inEscape) {
                var tagStart = row.substr(j + 1, 3)
                if (tagStart === 'nk-') {
                    inTag = true;
                    j += 3;
                    continue;
                }

                tagStart = row.substr(j + 1, 4)
                if (tagStart === '/nk-') {
                    inEndTag = true;
                    j += 4;
                    continue;
                }
            }

            if (symbol === '>' && !inEscape) {
                if (inEndTag) {
                    inEndTag = false;
                    if (inTemplateTag) {
                        if (templateAtrribute === 'name') {
                            templates[templateName] = contents;
                            contents = '';
                        }                        
                        inTemplateTag = false;
                        
                    }
                    if (inModel) {
                        inModel = false;
                        //console.log('-' + contents + '-');                        
                        text += dictionary[contents];
                        contents = '';
                    }

                    continue;
                }

                if (inTag) {
                    inTag = false;
                    if (tag.indexOf('template') >=0) {
                        var tagItems = tag.split(' ');
                        if (tagItems[0] === 'template') {
                            var tagAtrribute = tagItems[1].split('=');
                            templateAtrribute = tagAtrribute[0];
                            inTemplateTag = true;

                            if (templateAtrribute === 'name') {
                                templateName = tagAtrribute[1].substring(1, tagAtrribute[1].length - 1);
                            }

                            if (templateAtrribute === 'render') {
                                templateName = tagAtrribute[1].substring(1, tagAtrribute[1].length - 1);
                                text = templates[templateName];
                                inTemplateTag = false;
                                inEndTag = false;
                            }
                        }
                    }

                    if (tag.indexOf('model') >= 0) {
                        inModel = true;
                    }

                    continue;
                }

                tag = '';
            }

            if (symbol === '{') {
                if (!firstEscapeON) {
                    firstEscapeON = true;
                }
                else {
                    inEscape = true;
                    firstEscapeON = false;
                }
                continue;
            }

            if (symbol === '}') {
                if (!firstEscapeON) {
                    firstEscapeON = true;
                }
                else {
                    inEscape = false;
                    firstEscapeON = false;
                }
                continue;
            }

            if (inEndTag) {
                continue;
            }

            if (inTemplateTag || inModel) {
                contents += symbol;
                continue;
            }

            if (inTag) {
                tag += symbol;
            }
            else {
                text += symbol;
            }

        }
        //if (text === undefined) {
        //    text = '';
        //}
        var trimTest = text.trim();
        if (trimTest.length > 0) {
            result += text + '\n';
            text = '';
        }
        if (contents.length > 0) {
            contents += '\n';
        }
    }

    //console.log(templates);






    console.log(result.trim());
}

var test1 = [
'6',
'title-Telerik Academy',
'showSubtitle-true',
'subTitle-Free training',
'showMarks-false',
'marks-3;4;5;6',
'students-Ivan;Gosho;Pesho',
'21',
'<nk-template name="menu">',
'    <ul id="menu">',
'        <li>Home</li>',
'        <li>About us</li>',
'    </ul>',
'</nk-template>',
'<nk-template name="footer">',
'    <footer>',
'    Copyright Telerik Academy 2014',
'    </footer>',
'</nk-template>',
'<!DOCTYPE html>',
'<html>',
'<head>',
'    <title>Telerik Academy</title>',
'</head>',
'<body>',
'    <nk-template render="menu" />',
'    <h1><nk-model>title</nk-model></h1>',
'    <h2><nk-model>subTitle</nk-model></h2>',
'<div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
]


//solve(test1);
console.log('----------');

var test2 = [
'6',
'title-Telerik Academy',
'showSubtitle-true',
'subTitle-Free training',
'showMarks-false',
'marks-3;4;5;6',
'students-Ivan;Gosho;Pesho',
'42',
'<nk-template name="menu">',
'    <ul id="menu">',
'        <li>Home</li>',
'        <li>About us</li>',
'    </ul>',
'</nk-template>',
'<nk-template name="footer">',
'    <footer>',
'    Copyright Telerik Academy 2014',
'    </footer>',
'</nk-template>',
'<!DOCTYPE html>',
'    <html>',
'    <head>',
'    <title>Telerik Academy</title>',
'    </head>',
'    <body>',
'    <nk-template render="menu" />',
'    <h1><nk-model>title</nk-model></h1>',
'    <nk-if condition="showSubtitle">',
'    <h2><nk-model>subTitle</nk-model></h2>',
'    <div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
'    </nk-if>',
'    <ul>',
'    <nk-repeat for="student in students">',
'    <li>',
'    <nk-model>student</nk-model>',
'    </li>',
'    <li>Multiline <nk-model>title</nk-model></li>',
'    </nk-repeat>',
'    </ul>',
'    <nk-if condition="showMarks">',
'    <div>',
'    <nk-model>marks</nk-model>',
'    </div>',
'    Telerik Software Academy 2014 7 of 7 facebook.com/TelerikAcademy',
'</nk-if>',
'<nk-template render="footer" />',
'</body>',
'</html>',
];

var test3 = [
'0',
'15',
'<div>',
'    <p>',
'       {{<nk-if condition="pesho">}}',
'       {{escaped}} dude',
'    </p>',
'    <p>',
'       {{<nk-template render="pesho">}}',
'    </p>',
'    <p>',
'       {{<nk-repeat for="pesho in peshos">}}',
'       {{escaped}} in comment',
'   </p>',
'</div>'
];

var test4 = [
'0',
'21',
'<nk-template name="first">',
'    <ul>',
'        <li>',
'            In section UL',
'        </li>',
'        <li>',
'            Still in section UL',
'        </li>',
'    </ul>',
'</nk-template>',
'<nk-template name="second">',
'    <div>',
'        Second section :)',
'    </div>',
'</nk-template>',
'<div>',
'    <nk-template render="first" />',
'    <nk-template render="second" />',
'</div>'
];

console.log(solve(test3));
console.log('----------');
console.log(solve(test4));
