
// this homework is small so I combine the tasks in one script file

jsConsole.writeLine("--- Task 1 ---");
var boolVariable = true,
    integer = 23,
    hexadecimal = 0x123,
    realNumber = 1.23,
    string = 'Hello evaluating homework colleague!';
    array = ['home', 'work'];

jsConsole.writeLine("Boolean: " + boolVariable);
jsConsole.writeLine("Integer number: " + integer);
jsConsole.writeLine("Integer number: " + hexadecimal);
jsConsole.writeLine("Real number: " + realNumber);
jsConsole.writeLine("String: " + string);
jsConsole.writeLine("Array: " + array[0] + ", " + array[1]);

jsConsole.writeLine("--- Task 2 ---");
var gandalf = '"I am servant of the Secret Fire, wielder of the flame of Anor. You cannot pass. The dark fire will not avail you, flame of Udûn. Go back to the Shadow! You cannot pass." Gandalf said.';
jsConsole.writeLine(gandalf);

jsConsole.writeLine("--- Task 3 ---");
jsConsole.writeLine("typeof boolVariable: " + typeof (boolVariable));
jsConsole.writeLine("typeof integer: " + typeof (integer));
jsConsole.writeLine("typeof hexadecimal: " + typeof (hexadecimal));
jsConsole.writeLine("typeof realNumber: " + typeof (realNumber));
jsConsole.writeLine("typeof string: " + typeof (string));
jsConsole.writeLine("typeof array: " + typeof (array));
jsConsole.writeLine("typeof gandalf: " + typeof (gandalf));

jsConsole.writeLine("--- Task 4 ---");
var nullVariable = null,
    undefVariable = undefined;

jsConsole.writeLine("Typeof 'null' variable: " + typeof (nullVariable));
jsConsole.writeLine("Typeof 'undefined' variable: " + typeof (undefVariable));