// const $xhr = document.getElementById("cliente"),
// $fragment = document.createDocumentFragment();

// fetch("https://localhost:5001/api/cliente")
// .then(response=>{
//     return response.ok ? response.json(response.body) : Promise.reject(response);
// })
// .then(result=> {
//     result.forEach(el => {
//         const $li = document.createElement("li");
//         $li.innerHTML = `${el.nombres}`;
//         $fragment.appendChild($li);
//     });
//     $xhr.appendChild($fragment); 
// })
// .catch(ex=>{
//     console.log(`${ex.status} Error`);
// })
// .finally();

let $btnsave = document.getElementById("btnsave");
$btnsave.addEventListener("click",saveData);

function saveData()
{
    const $nameInput = document.getElementById("nameInput");
    const $lastnameInput = document.getElementById("lastnameInput");
    const $dateInput = document.getElementById("dateInput");
    


    let data = {
        nombres: $nameInput.value,
        apellidos:$lastnameInput.value,
        fechaNacimiento: $dateInput.value
    }
 
    console.log(data);
    fetch("https://localhost:5001/api/cliente",{
        headers: {"Content-type": "application/json; charset=UTF-8"},
        method: 'POST',
        body: JSON.stringify(data)
    })
    .then(function(response) {  
        if(response.ok) {
            return response.text()
        } else {
            throw "Error en la llamada Ajax";
        }
     });
}