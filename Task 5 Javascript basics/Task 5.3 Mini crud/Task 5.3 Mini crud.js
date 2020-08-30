class Service {
    constructor() {
        self.storage = new Map();
        self.currentId = 0;
    }
    
    add(object) {
        if (this.validateObject(object)) {
            self.storage.set(String(self.currentId), object);
            currentId++;
        }                                            
    }
    
    getById(id) {
        if (this.validateId(id) == true && this.validateObjectById(id) == true) {
            return self.storage.get(id);
        }
    }
    
    getAll() {
        let result = new Array();
        
        for (let item of self.storage.values()) {
            result.push(item);
        }
        
        return result;
    }
    
    deleteById(id) {
        if (this.validateId(id) && this.validateObjectById(id)) {
            self.storage.delete(id);
        }
    }
    
    updateById(id, object) {
        if (this.validateId(id) && this.validateObject(object) && this.validateObjectById(id)) {
            let tmpObject = Object.assign(self.storage.get(id), object);
            self.storage.set(id, tmpObject);
        } 
    }
    
    replaceById(id, object) {
        if (this.validateId(id) && this.validateObject(object) && this.validateObjectById(id)) {
            self.storage.set(id, object);
        }    
    }
    
    validateObject(object) {
        if (typeof(object) == "object") {
            return true;
        }                                            
        else {
            console.log("Object isn't object");
            return false;
        }    
    }
    
    validateId(id) {
        if (typeof(id) == "string") {
            return true; 
        }
        else {
            console.log("Id isn't string");
            return false;
        }
    }
    
    validateObjectById(id) {
        if (self.storage.has(id)) {
            return true;
        }
        else {
            console.log("Id doesn't exist");
            return false;
        }    
    }
}