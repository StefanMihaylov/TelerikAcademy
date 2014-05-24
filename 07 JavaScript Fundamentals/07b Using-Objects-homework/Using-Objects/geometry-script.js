/*global _comma_separated_list_of_variables_*/
function point(xCoord, yCoord) {
    return {
        X: xCoord,
        Y: yCoord,
        toString: function () {
            return "{" + this.X + ";" + this.Y + "}";
        }
    };
}

function line(firstPoint, secondPoint) {
    return {
        firstPoint: firstPoint,
        secondPoint: secondPoint,
        getLength: function () {
            var xCoord = firstPoint.X - secondPoint.X,
                yCoord = firstPoint.Y - secondPoint.Y;
            return Math.sqrt((xCoord * xCoord) + (yCoord * yCoord));
        }
    };
}

function readLineCoord(name) {
    var point1X = readInt(name + "X1"),
        point1Y = readInt(name + "Y1"),
        point1,
        point2X = readInt(name + "X2"),
        point2Y = readInt(name + "Y2"),
        point2;

    if (point1X === null || point1Y === null || point2X === null || point2Y === null) {
        return null;
    }

    point1 = point(point1X, point1Y);
    point2 = point(point2X, point2Y);
    return line(point1, point2);
}

function checkTriangle(line1, line2, line3) {
    var side1 = line1.getLength(),
        side2 = line2.getLength(),
        side3 = line3.getLength();

    return ((side1 + side2 > side3) &&
        (side1 + side3 > side2) &&
        (side2 + side3 > side1));
}

function testFormTriangle() {
    var line1 = readLineCoord("line1"),
        line2 = readLineCoord("line2"),
        line3 = readLineCoord("line3"),
        result;

    if (line1 === null || line2 === null || line3 === null) {
        return;
    }

    jsConsole.writeLine("Line1 -> Distance between " + line1.firstPoint.toString() +
        " and " + line1.secondPoint.toString() + " is " +
        Math.round(line1.getLength() * 100) / 100);
    jsConsole.writeLine("Line2 -> Distance between " + line2.firstPoint.toString() +
        " and " + line2.secondPoint.toString() + " is " +
        Math.round(line2.getLength() * 100) / 100);
    jsConsole.writeLine("Line3 -> Distance between " + line3.firstPoint.toString() +
        " and " + line3.secondPoint.toString() + " is " +
        Math.round(line3.getLength() * 100) / 100);

    result = checkTriangle(line1, line2, line3);
    jsConsole.writeLine("Can this lines form a triangle? -> " + (result ? "Yes" : "No"));
}