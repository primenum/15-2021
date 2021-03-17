

function applyIfDefined(callBackFn) {
    if (typeof(callBackFn)!== 'function')
    {
        return undefined;
    }

    return function (...args) {
        
        //check callback function input length 
        if (callBackFn.length <= args.length) {

            //check that callback input parameters are valid, all others not relevant
            for (let i=0; i<callBackFn.length; i++)
            {
                //check argument requirments
                if (typeof(args[i]) === 'undefined' || args[i] === null)
                return undefined;
            }

            //call callback function with correct "this" context
            return callBackFn.apply(this,args);
        }
    }
}


///test various of inputs

test = () => 
{
    console.log('Test for  applyIfDefined(), expect undefind');
    console.log(applyIfDefined());

    console.log('Test for  applyIfDefined((a,b) => {console.log(a+b)})(1,null), expect undefind');
    console.log(applyIfDefined((a,b) => {return a+b})(1,null));
    

    console.log('Test for  applyIfDefined((a,b) => {console.log(a+b)})(undefined,2), expect undefind');
    console.log(applyIfDefined((a,b) => {return a+b})(undefined,2));
    
    console.log('Test for  applyIfDefined((a,b) => {console.log(a+b)})( 2,2), expected 4');
    console.log(applyIfDefined((a,b) => {return a+b})( 2,2));


    console.log('Test for  applyIfDefined((a,b) => {console.log(a+b)})(2,3,null), expected 5');
    console.log(applyIfDefined((a,b) => {return a+b})(2,3, null));
};
test();


//
class Car{
};
Car.prototype.setModel = applyIfDefined(function (model)
{
    this.model = model;
});

let myCar = new Car();
myCar.setModel('volvo');
console.log(myCar.model);
myCar.setModel(null);
console.log(myCar.model);
