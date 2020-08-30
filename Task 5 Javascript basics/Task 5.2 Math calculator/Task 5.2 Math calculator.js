function mathCalculator(str) {
    mathExpr = splitMathExpr(str);
    let result = 0;
    
    for (let i = 0; i < mathExpr.length; i += 2) {
        switch(mathExpr[i]) {
            case '+':
                result += Number(mathExpr[i + 1]);
                break;
            case '-':
                result -= Number(mathExpr[i + 1]);
                break;
            case '*':
                result *= Number(mathExpr[i + 1]);
                break;
            case '/':
                result /= Number(mathExpr[i + 1]);
                break;
            case '=':
                break;
            default:
                result += Number(mathExpr[i]);
        }
    }
    
    return result.toFixed(2) 
}

function splitMathExpr(str) {
    var operators = new Set(['+', '-', '*', '/', '='])
    str = str.replace(/\s/g, '');
    let result = new Array();
    
    let currentObject = new String();
    for (let i = 0; i < str.length; i++) {
        if (operators.has(str[i])) {
            result.push(currentObject);
            currentObject = "";
            result.push(str[i]);
        }
        else {
            currentObject += str[i];
        }   
    }
    
    return result;
}