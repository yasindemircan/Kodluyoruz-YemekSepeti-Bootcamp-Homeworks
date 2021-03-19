import React, { Component } from 'react';
import { MdAdd } from 'react-icons/md';
const PageSize = window.innerWidth;
export default class Inputs extends Component {
  state = {
    InputBox: "",
  }
  render() {
    const { TodoList, SetTodoList, AddToList, DeleteInList } = this.props;
    return (
      <div className="Inputs">
        <input type="text" className="Text-input"
          placeholder="Add a New Todo"
          value={this.state.InputBox}
          onKeyDown={(e) => {
            if (e.key === "Enter") {
              AddToList(SetTodoList, TodoList, this.state.InputBox)
              this.setState({ InputBox: "" });
            } else if (e.key === "Delete") {
              DeleteInList(TodoList[TodoList.length - 1], TodoList, SetTodoList)
            }
          }}
          onChange={(e) => { this.setState({ InputBox: e.target.value }) }} />
        <button type="button" className="Add-Button" onClick={() => {
          AddToList(SetTodoList, TodoList, this.state.InputBox)
          this.setState({ InputBox: "" })
        }}><MdAdd size="24" /> {PageSize > 500 ? " Add To List" : null}</button>
      </div>
    )
  }
}
