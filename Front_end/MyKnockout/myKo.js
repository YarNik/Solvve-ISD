
        let myKo = {
            applyBindings(model) {                
                let arrTagValue = {};
                let elementsDataBind = document.querySelectorAll('[data-bind]');
                for (let i = 0; i < elementsDataBind.length; i++) {                   
                    let valueAttrDataBind = elementsDataBind[i].getAttribute('data-bind');
                    if (valueAttrDataBind.indexOf("text: ", 0) == 0)
                    {
                        let valueAttrDataBindText = valueAttrDataBind.slice(6);                    
                        for (key in model) 
                        {
                            if (key == valueAttrDataBindText)
                            { elementsDataBind[i].innerHTML = model[key]; }
                        }
                    }
                    if (valueAttrDataBind.indexOf("value: ", 0) == 0)
                    {
                        let valueAttrDataBindValue = valueAttrDataBind.slice(7);                        
                        arrTagValue[valueAttrDataBindValue] = elementsDataBind[i];
                    }
                    if (valueAttrDataBind.indexOf("calculate: ", 0) == 0)
                    {
                        let attr1;
                        let operator;
                        let attr2;
                        let contentCalculateEnd;
                        let contentCalculate = valueAttrDataBind.slice(11);                         
                        for (key in model) 
                        {
                            if (contentCalculate.indexOf(key) == 0) 
                            {
                                attr1 = model[key];                                
                                operator = contentCalculate[key.length];                                
                                contentCalculateEnd = contentCalculate.slice(key.length + 1);                               
                            }
                        }
                        for (key in model) 
                        {
                            if (contentCalculateEnd.indexOf(key) == 0) attr2 = model[key];                           
                        }
                        if (operator == "+") elementsDataBind[i].innerHTML = attr1 + attr2;
                        if (operator == "-") elementsDataBind[i].innerHTML = attr1 - attr2;
                        if (operator == "*") elementsDataBind[i].innerHTML = attr1 * attr2;
                        if (operator == "/") elementsDataBind[i].innerHTML = attr1 / attr2;
                        if (operator == "^") 
                            {                                
                                function inputDate(str) 
                                {
                                    let year = parseInt(str.substring(0,4));
                                    let month = parseInt(str.substring(5,7)) - 1;
                                    let day = parseInt(str.substring(8));                     
                                    return new Date(year, month, day);
                                }
                                let result = (inputDate(attr1) - inputDate(attr2)) / (1000*3600*24);
                                if (result < 0) result = 0;                          
                                elementsDataBind[i].innerHTML = result;                                
                                viewModel.resultDate = result;                               
                            }
                    }
                }

                let arrOnInput = []
                for (key in arrTagValue)
                 { arrOnInput.push(key); }                 
                
                for (let i = 0; i < arrOnInput.length; i++)
                {
                    arrTagValue[arrOnInput[i]].oninput = function() { 
                        let protectedString =  arrTagValue[arrOnInput[i]].value.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");                 
                        viewModel[arrOnInput[i]] = protectedString;                       
                        if (arrOnInput[i].substring(0,5) == "radio")
                            {
                                viewModel.radioPrice = arrTagValue[arrOnInput[i]].value;
                            }                                                                              
                        myKo.applyBindings(viewModel);
                    }
                }

            }
        }