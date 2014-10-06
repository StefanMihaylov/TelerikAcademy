module.exports = function (grunt) {
    grunt.initConfig({
        coffee: {
            dev: {
                files: {
                    'dev/scripts/script.js': 'app/scripts/script.coffee'
                }
            }
        },
        jade: {
            compile: {
                options: {
                    data: {
                        debug: false
                    }
                },
                files: {
                    "dev/index.html": ["app/index.jade"]
                }
            }
        },
        jshint: {
            all: ['dev/scripts/**/*.js']
        },
        stylus: {
            dev: {
                files: {
                    'dev/styles/main.css': 'app/styles/main.styl'
                }
            }
        },
        copy: {
            files: {
                cwd: 'app/images',  // set working folder / root to copy
                src: '**/*',           // copy all files and subfolders
                dest: 'dev/images',    // destination folder
                expand: true           // required when using cwd
            }
        },
        connect: {
            options: {
                port: 9001,
                livereload: 35729,
                hostname: 'localhost'
            },
            livereload: {
                options: {
                    open: true,
                    base: 'dev'
                }
            }
        },
        watch: {
            jade: {
                files: ['app/**/*.jade'],
                tasks: ['jade'],
                options: {
                    livereload: true
                }
            },
            coffee: {
                files: ['app/scripts/**/*.coffee'],
                tasks: ['coffee'],
                options: {
                    livereload: true
                }
            },
            stylus: {
                files: ['app/styles/**/*.styl'],
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            js: {
                files: ['Gruntfile.js', 'dev/scripts/**/*.js'],
                tasks: ['jshint'],
                options: {
                    livereload: true
                }
            },
            css: {
                files: ['app/styles/**/*.styl'],
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            html: {
                files: ['dev/index.html'],
                options: {
                    livereload: true
                }
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
                    'dev/**/*.html',
                    'dev/**/*.css',
                    'dev/**/*.js'
                ]
            }
        }
    });

    require('load-grunt-tasks')(grunt);

    grunt.registerTask('serve', ['coffee', 'jshint', 'jade', 'stylus', 'copy', 'connect', 'watch']);
};
