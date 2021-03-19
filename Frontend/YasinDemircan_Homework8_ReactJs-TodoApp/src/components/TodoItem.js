import React, { Component } from 'react'
import { MdDelete } from 'react-icons/md';
const PageSize = window.innerWidth;
export default class TodoItem extends Component {

    render() {
        const { List, SetTodoList, DeleteInList } = this.props;
        window.localStorage.setItem("List", JSON.stringify(List));
        const rows = [];
        for (let i = 0; i < List.length; i++) {
            rows.push(<div className="Context-Item" key={i}>
                <div className="Context-Item-Text">{List[i]} </div>
                <div className="Context-Item-DeleteBtn" onClick={(e) => DeleteInList(List[i], List, SetTodoList)}>{PageSize > 500 ? "Delete" : null} <MdDelete size="25" /> </div>
            </div>)
        }
        return (rows.reverse())
    }
}


