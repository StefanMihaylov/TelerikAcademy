window.onload = function () {

    var Draw = (function (canvasID) {

        function Draw(canvasID) {
            // John Resig fix if the function is not used as constructor
            if (!(this instanceof arguments.callee)) {
                return new Draw(canvasID);
            }

            this.content = document.getElementById(canvasID).getContext('2d');
        }

        function setColours(settings) {
            if (settings.fillColor) {
                this.content.fillStyle = settings.fillColor;
                this.content.fill();
            }

            var currentLineWidth = settings.lineWidth || 1;
            this.content.lineWidth = currentLineWidth;

            if (settings.strokeColor) {
                this.content.strokeStyle = settings.strokeColor;
                this.content.stroke();
            }
        }

        Draw.prototype.rect = function (startX, startY, width, height, settings) {
            this.content.beginPath();
            this.content.rect(startX, startY, width, height);
            setColours.call(this, settings);

        };

        Draw.prototype.circle = function (centerX, centerY, radius, settings) {
            this.content.beginPath();
            this.content.arc(centerX, centerY, radius, 0, 2 * Math.PI);
            setColours.call(this, settings);
        }

        Draw.prototype.line = function (startX, startY, endX, endY, settings) {
            this.content.beginPath();
            this.content.moveTo(startX, startY);
            this.content.lineTo(endX, endY);
            setColours.call(this, settings);
        }

        return Draw;
    }());


    var drawer = new Draw('canvas-element');

    drawer.rect(50, 50, 150, 80, { fillColor: 'green', strokeColor: 'black', lineWidth: 3 });
    drawer.rect(300, 50, 150, 80, { strokeColor: 'blue', lineWidth: 5 });
    drawer.rect(550, 50, 150, 80, { fillColor: 'red' });

    drawer.circle(100, 200, 50, { fillColor: 'green', strokeColor: 'black', lineWidth: 3 });
    drawer.circle(350, 200, 50, { strokeColor: 'blue', lineWidth: 5 });
    drawer.circle(600, 200, 50, { fillColor: 'red' });

    drawer.line(100, 350, 300, 300, { strokeColor: 'green', lineWidth: 5 });
    drawer.line(500, 300, 700, 350, { strokeColor: 'red' });
}