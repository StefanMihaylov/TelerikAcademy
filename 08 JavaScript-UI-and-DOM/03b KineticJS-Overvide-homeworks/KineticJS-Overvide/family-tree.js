window.onload = function () {
    var male = 'male';
    var female = 'female';

    // initialize canvas
    var stage = new Kinetic.Stage({
        container: 'canvas-wrapper',
        width: 1800,
        height: 1200
    });

    // run one of two sets of Data
    document.querySelector('#default-data').addEventListener('click', function () {
        calculateAndDrawTree(data1(), stage); // default data
    });

    document.querySelector('#large-data').addEventListener('click', function () {
        calculateAndDrawTree(data2(), stage); // data 'stolen' form Telerik Academy forum :)
    });

    // main function
    function calculateAndDrawTree(data, canvasStage) {

        var boxSettings = {
            fontFamily: 'Calibri',
            fontSize: 12,
            padding: 10,
            borderWidth: 4,
            maxWidth: '',
            maxHeight: '',
            partnerDistance: 20,
            childDistance: 80
        };

        canvasStage.clear();
        var layer = new Kinetic.Layer();

        var tree = arrangePerson(data);
        maxBoxDimentions(tree, boxSettings);

        var rootPerson = findRoot(tree);
        drawTree(tree, boxSettings, rootPerson, (window.innerWidth - boxSettings.maxWidth) / 2, 20, layer);
        canvasStage.add(layer);
    }

    function drawPerson(text, sex, centerX, centerY, settings, layer) {

        var sexColor,
            borderRadius;

        if (sex === male) {
            sexColor = '#00BFFF';
            borderRadius = 7;
        } else if (sex === female) {
            sexColor = '#FF69B4';
            borderRadius = 15;
        } else {
            sexColor = 'black';
            borderRadius = 0;
        }

        var testText = new Kinetic.Text({
            text: text,
            fontSize: settings.fontSize,
            fontFamily: settings.fontFamily,
            padding: settings.padding
        });

        width = testText.width();
        height = testText.height();

        var complexText = new Kinetic.Text({
            x: centerX - width / 2,
            y: centerY - height / 2,
            fill: '#333',
            text: text,
            fontSize: settings.fontSize,
            fontFamily: settings.fontFamily,
            padding: settings.padding,
            align: 'center'
        });

        var rect = new Kinetic.Rect({
            fill: '#D0D0D0',
            stroke: sexColor,
            x: centerX - settings.maxWidth / 2,
            y: centerY - settings.maxHeight / 2,
            strokeWidth: settings.borderWidth,
            height: settings.maxHeight,
            width: settings.maxWidth,
            cornerRadius: borderRadius,
            shadowColor: 'black',
            shadowBlur: 10,
            shadowOffset: { x: 3, y: 3 },
            shadowOpacity: 0.5
        });

        layer.add(rect);
        layer.add(complexText);
    }

    function arrangePerson(familyMembers) {
        var tree = [];

        // split the families to individual people
        for (var i = 0; i < familyMembers.length; i++) {
            var family = familyMembers[i];
            if (family.hasOwnProperty('mother')) {
                tree[family.mother] = {
                    sex: female,
                    partner: family.father,
                    children: family.children,
                    father: searchForParents(tree, family.mother),
                    position: ''
                };
            }

            if (family.hasOwnProperty('father')) {
                tree[family.father] = {
                    sex: male,
                    partner: family.mother,
                    children: family.children,
                    father: searchForParents(tree, family.father),
                    position: ''
                };
            }

            if (family.hasOwnProperty('children')) {
                var childredList = family.children;
                for (var j = 0; j < childredList.length; j++) {
                    if (tree[childredList[j]]) {
                        tree[childredList[j]].father = family.father;
                    }
                    else {
                        tree[childredList[j]] = {
                            sex: '',
                            partner: null,
                            children: null,
                            father: family.father,
                            position: ''
                        };
                    }
                }
            }
        }

        return tree;
    }

    function searchForParents(tree, childName) {
        for (var personName in tree) {
            var person = tree[personName];
            if (person.sex === male) {
                var children = person.children;
                if (children) {
                    for (var i = 0; i < children.length; i++) {
                        if (childName === children[i]) {
                            return personName;
                        }
                    }
                }
            }
        }
        return null;
    }

    function findRoot(tree) {
        for (var personName in tree) {
            var person = tree[personName];
            if (person.sex === male && person.father === null) {
                var partner = person.partner;
                if (partner && tree[partner].father === null) {
                    return personName;
                }
            }
        }
        return null;
    }

    function maxBoxDimentions(tree, settings) {
        var maxWidth = 0,
            maxHeight = 0,
            height,
            width;

        for (var personName in tree) {
            var testText = new Kinetic.Text({
                text: personName,
                fontSize: settings.fontSize,
                fontFamily: settings.fontFamily,
                padding: settings.padding,
            });

            width = testText.width();
            height = testText.height();

            if (width > maxWidth) {
                maxWidth = width;
            }

            if (height > maxHeight) {
                maxHeight = height;
            }
        }

        settings.maxWidth = maxWidth;
        settings.maxHeight = maxHeight;
    }

    function drawConnection(startX, startY, endX, settings, layer) {
        var halfDistance = (settings.maxWidth + settings.partnerDistance) / 2;
        var lineStart = startX + halfDistance;
        var middleLinePoint = (settings.childDistance - settings.maxHeight) / 3;
        var endY = startY - settings.borderWidth / 2 + (settings.maxHeight / 2) + 3 * middleLinePoint;
        var line = new Kinetic.Line({
            points: [lineStart, startY,
                     lineStart, endY - 2 * middleLinePoint,
                     endX, endY - middleLinePoint,
                     endX, endY,
                     endX - 2, endY - middleLinePoint / 2,
                     endX + 2, endY - middleLinePoint / 2,
                     endX, endY],
            stroke: 'green',
            strokeWidth: 3,
            lineCap: 'round',
            lineJoin: 'round',
        });
        layer.add(line);
    }

    function drawParentsConnestion(partner1X, partner2X, positionY, settings, layer) {
        var partnerLineHeigth = 6;

        var fatherPosition = partner1X;
        if (fatherPosition > partner2X) {
            fatherPosition = partner2X;
        }

        var rect = new Kinetic.Rect({
            fill: 'black',
            height: partnerLineHeigth,
            x: fatherPosition + settings.maxWidth / 2,
            y: positionY - partnerLineHeigth / 2,
            width: settings.partnerDistance,
        });
        layer.add(rect);
    }

    function personPosition(person, positionX, settings) {
        var personPosition = positionX;
        if (person.sex === female) {
            personPosition = positionX + (settings.maxWidth + settings.partnerDistance);
        }
        return personPosition;
    }

    function distanceCoefficients(array) {
        var coef = [];
        if (array.length === 1) {
            coef[0] = 0;
        }
        else if (array.length === 2) {
            coef[0] = -1;
            coef[1] = 1;
        }
        else if (array.length === 3) {
            coef[0] = -2;
            coef[1] = 0;
            coef[2] = 2;
        }

        return coef;
    }

    function drawTree(tree, settings, personName, positionX, positionY, layer) {

        // person
        var person = tree[personName];
        var positionPerson = personPosition(person, positionX, settings);
        tree[personName].position = positionPerson;
        drawPerson(personName, person.sex, positionPerson, positionY, settings, layer);

        // partner
        var partnerName = person.partner;
        var partner = tree[partnerName];
        if (partner) {
            var positionPartner = personPosition(partner, positionX, settings);
            tree[partnerName].position = positionPartner;

            drawPerson(partnerName, partner.sex, positionPartner, positionY, settings, layer);
            drawParentsConnestion(positionPerson, positionPartner, positionY, settings, layer);
        }

        // children
        var children = person.children;
        if (children) {
            var coef = distanceCoefficients(children);
            var fatherPosition = positionX;
            for (var i = 0; i < children.length; i++) {
                childPosition = fatherPosition + coef[i] * (settings.maxWidth + settings.partnerDistance);
                tree[children[i]].position = childPosition;
                drawTree(tree, settings, children[i], childPosition, positionY + settings.childDistance, layer);
                drawConnection(fatherPosition, positionY, tree[children[i]].position, settings, layer);
            }
        }
    }
};