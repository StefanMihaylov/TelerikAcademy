window.onload = function () {

    // this window settings ar158e set for resolution 1366x768, 
    // If you screen has different resolution, Mario position can be incorrect
    // only left and right movements are imprelemted
    // most of sprite pictures are not get precisely
    var marioOffsetY = 156;
    var width = window.innerWidth - 10;
    var height = window.innerHeight - 10;
    var marioSpeed = 7;

    // put background
    var paper = new Raphael("background", width, height);
    paper.image('background.jpg', 5, 0, width, height);

    // initialize canvas
    var stage = new Kinetic.Stage({
        container: 'canvas',
        width: width,
        height: height
    });

    var layer = new Kinetic.Layer();

    var marioSplite = new Image();
    marioSplite.src = 'mlbosfmario.png';
    marioSplite.onload = function () {

        var mario = new Kinetic.Sprite({
            x: width / 2,
            y: height - marioOffsetY,
            image: marioSplite,
            animation: 'idle',
            animations: {
                // x, y, width, height
                idle: [
                    527, 2, 43, 82
                ],
                turnRigth: [
                    527, 2, 43, 82,
                    527, 103, 43, 82,
                    527, 205, 43, 82
                ],
                turnRigthToIdle: [
                    527, 205, 43, 82,
                    527, 103, 43, 82,
                    527, 2, 43, 82
                ],

                idleRight: [
                    527, 205, 43, 82
                ],
                turnLeft: [
                    527, 2, 43, 82,
                    527, 712, 43, 82,
                    527, 611, 43, 82
                ],
                turnLeftToIdle: [
                    527, 611, 43, 82,
                    527, 712, 43, 82,
                    527, 2, 43, 82
                ],
                idleLeft: [
                    527, 611, 43, 82
                ],
                walkingLeft: [
                    395, 611, 43, 82,
                    341, 611, 43, 82,
                    287, 611, 43, 82,
                    233, 611, 43, 82,
                    178, 611, 43, 82,
                    123, 611, 43, 82,
                    69, 611, 43, 82
                ],
                walkingRight: [
                    527, 208, 43, 82,
                    70, 208, 43, 82,
                    123, 208, 43, 82,
                    178, 208, 43, 82,
                    233, 208, 43, 82,
                    287, 208, 43, 82,
                    343, 208, 43, 82
                ]
            },
            frameRate: 10,
            frameIndex: 0
        });

        // add the shape to the layer
        layer.add(mario);

        // add the layer to the stage
        stage.add(layer);

        // start sprite animation
        mario.start();

        var frameCount = 0;
        var newPosition = 0;
        mario.on('frameIndexChange', function (event) {
            if (mario.animation() === 'turnRigth' && ++frameCount > 3) {
                mario.animation('idleRight');
                frameCount = 0;
            } else if (mario.animation() === 'turnLeft' && ++frameCount > 3) {
                mario.animation('idleLeft');
                frameCount = 0;
            } else if (mario.animation() === 'turnRigthToIdle' && ++frameCount > 3) {
                mario.animation('idle');
                frameCount = 0;
            } else if (mario.animation() === 'turnLeftToIdle' && ++frameCount > 3) {
                mario.animation('idle');
                frameCount = 0;
            } else if (mario.animation() === 'walkingLeft') {
                newPosition = mario.attrs.x - marioSpeed;
                if (newPosition <= 0) {
                    mario.animation('idleLeft');
                } else {
                    mario.setX(newPosition);
                }

                if (++frameCount > 7) {
                    mario.animation('idleLeft');
                    frameCount = 0;
                }
            } else if (mario.animation() === 'walkingRight') {
                newPosition = mario.attrs.x + marioSpeed;
                if (newPosition >= width - 43) {
                    mario.animation('idleRight');
                } else {
                    mario.setX(newPosition);
                }

                if (++frameCount > 7) {
                    mario.animation('idleRight');
                    frameCount = 0;
                }
            }
        });

        window.addEventListener('keydown', function (event) {
            switch (event.keyCode) {
                case 37: // key left
                    switch (mario.animation()) {
                        case 'idle':
                            mario.animation('turnLeft');
                            break;
                        case 'idleRight':
                            mario.animation('turnRigthToIdle');
                            break;
                        case 'idleLeft':
                            mario.animation('walkingLeft');
                            break;
                        case 'walkingRight':
                            mario.animation('idleRight');
                            break;
                    }
                    break;
                case 39: // key right                    
                    switch (mario.animation()) {
                        case 'idle':
                            mario.animation('turnRigth');
                            break;
                        case 'idleLeft':
                            mario.animation('turnLeftToIdle');
                            break;
                        case 'walkingLeft':
                            mario.animation('idleLeft');
                            break;
                        case 'idleRight':
                            mario.animation('walkingRight');
                            break;
                    }
                    break;
            }
            layer.draw();
        });
    };
};