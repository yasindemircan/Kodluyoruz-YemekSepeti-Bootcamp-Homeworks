
const button = document.querySelector("#button-input");
const textInput = document.querySelector("#taskInput");
const ul = document.querySelector("#taskList");

button.addEventListener("click", function (e) {
     addToList(textInput.value)
     render()
});
var taskList = [];
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


function render() {
  ul.innerHTML = '';
  taskList.map((item) => {
    console.log("render item:",item)
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

