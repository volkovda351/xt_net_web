function charRemover(str) {
    repeatedChars = calcRepeatedChars(str);
      
    let result = new String();
    
    for (let item of str) {
        if (!repeatedChars.has(item)) {
            result += item;
        }  
    }
    
    return result;
}

function calcRepeatedChars(str) {
    let words = str.split(" ");
    
    result = new Set();
    
    for (let word of words) {
        tmpDict = new Map();
        
        for (let chr of word) {
            if (tmpDict.has(chr)) {
                tmpDict.set(chr, tmpDict.get(chr) + 1);
            }
            else {
                tmpDict.set(chr, 1);
            }    
        }
        
        for (let [key, value] of tmpDict) {
            if (value > 1) {
                result.add(key);
            }
        }
    }
    
    return result;
}