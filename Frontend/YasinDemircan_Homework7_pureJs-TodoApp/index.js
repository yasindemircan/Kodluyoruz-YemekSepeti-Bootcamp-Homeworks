// create element - ul appendChild yap
// kopyala yapıştır yaptık, fonksiyonla yapsak daha iyiydi
// kod çirkin duruyor, kod okunaklı güzel görünsün.
// javascript kodunu ayır +
// querySelector kullanalım (getElementById yerine)+
// Özgür -  Ahmet Suhan için ->  css'lleri obje yap  -> en son "li" elementi renklendir.
// Taskları localStorage'e kaydet ve sayfa yenilendiğinde oradan al

const button = document.querySelector("#button-input");
const textInput = document.querySelector("#taskInput");
const ul = document.querySelector("#taskList");

button.addEventListener("click", function (e) {
     addToList(textInput.value)
     render()
});
var taskList = [
  "Daha Güzel Tasarım",
  "Todo lar çalışır hale getirilicek",
  "herhagi bir task",
];
if (JSON.parse(localStorage.getItem('taskList')))
  taskList = JSON.parse(localStorage.getItem('taskList'));
else
  localStorage.setItem("taskList", JSON.stringify(taskList));

render();

function addToList( task ){
	taskList.push(task);
	localStorage.setItem('taskList', JSON.stringify( taskList ));
	document.querySelector('#taskInput').value = '';
}



//  let listElements = "";
function render() {
  ul.innerHTML = '';
  taskList.map((item) => {
    console.log("render item:",item)
    // const li_Item = document.createElement("li");
    // const deleteBtn = document.createElement("button");
    var listItem = document.createElement('li'),
    taskLabel = document.createElement('label'),
    delBtn = document.createElement('span');
    

    listItem.className = 'task';
		listItem.id = taskList.indexOf( item );


		taskLabel.className = 'taskLabel';
		taskLabel.textContent = item;
		taskLabel.htmlFor = 'c' + taskList.indexOf( item );

		delBtn.className = 'deleteTaskBtn';
		delBtn.textContent = 'x';
		delBtn.onclick = deleteThisTask;

    listItem.appendChild( taskLabel );
		listItem.appendChild( delBtn );
			  ul.appendChild( listItem );

        saveLocalList();
  });
}

function deleteThisTask(e) {
	taskList.splice( e.target.parentElement.id, 1 );

	saveLocalList();
	render();
}

function saveLocalList() {
	localStorage.setItem("taskList", JSON.stringify( taskList ));
}

//console.log("listElement",listElements);

// taskList.map((item, index) => {
//   console.log("tasklistmap", taskList);
//   document
//     .querySelector("#btn_sil_" + item)
//     .addEventListener("click", function (e) {
//       console.log("r");
//       if (e.target.getAttribute("item") == item) {
//         let findIndex = taskList.findIndex((item) => item == li_Item.innerText);
//         console.log("r", findIndex);
//         console.log(taskList.splice(index, 1));
//         console.log(taskList);
//         ulList.innerHTML = "";
//         render();

//       }
//     });
// });

// button.addEventListener("click", function (e) {
//   taskList.push(textInput.value);

//   let listElements = "";
//   taskList.map((item) => {
//     console.log(item);
//     const myTask = `<li>${item}</li>`;
//     listElements += myTask;
//   });
//   ulList.innerHTML = listElements;
// });    

