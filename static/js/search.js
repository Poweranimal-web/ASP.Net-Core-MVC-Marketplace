window.addEventListener("DOMContentLoaded", function(){
const mainBlock = document.querySelector("main");
const mainCopy = mainBlock.cloneNode(true); 
const search = document.querySelector("input#search");
search.addEventListener("input",searchText);
async function searchText(event){
    let text = event.target.value;
    if (text.length > 0){
        const response = await fetch("/", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ text: text }),
        });
        if (response.ok){
            let res = await response.json();
            let childElements = document.createElement("div");
            childElements.className = "component-result";
            res.map((product)=>{
                let element = document.createElement("h1");
                let name = document.createTextNode(product.name);
                element.appendChild(name);
                childElements.appendChild(element);
            });
            mainBlock.replaceChildren(childElements);
            console.log(mainCopy);
        }
    }
    else{
        console.log(mainCopy);
        mainBlock.replaceChildren(...mainCopy.childNodes);
        console.log(mainCopy);
    }
}
});

