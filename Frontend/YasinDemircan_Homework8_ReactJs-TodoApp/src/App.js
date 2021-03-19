import "./css/App.css";
import React, { useState } from "react";
import TodoItem from "./components/TodoItem";
import Inputs from "./components/Inputs";

const AddToList = (SetTodoList, TodoList, InputBox) => {
  if (!InputBox.length > 0) {
    alert("Bos Ekleme Yapılamaz");
  }
  let Task = InputBox.trim();
  if (Task.length > 0) {
    SetTodoList([...TodoList, InputBox]);
  }
};
const DeleteInList = (SelectedItem, List, SetTodoList) => {
  const newList = List.filter((itemText) => itemText !== SelectedItem);
  SetTodoList(newList);
};

function App() {
  const [TodoList, SetTodoList] = useState(
    window.localStorage.getItem("List")
      ? JSON.parse(window.localStorage.getItem("List"))
      : []
  );
  return (
    <div className="App">
      <h1>Todo App</h1>

      <Inputs
        TodoList={TodoList}
        SetTodoList={SetTodoList}
        AddToList={AddToList}
        DeleteInList={DeleteInList}
      />
      <div className="Context-List">
        {
          <TodoItem
            List={TodoList}
            SetTodoList={SetTodoList}
            DeleteInList={DeleteInList}
          />
        }
      </div>
    </div>
  );
}

export default App;
