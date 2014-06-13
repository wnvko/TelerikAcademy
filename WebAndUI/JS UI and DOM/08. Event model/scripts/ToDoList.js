var todo = document.getElementsByTagName('textarea')[0],
    myForm = document.getElementsByTagName('form')[0],
    addButton = document.getElementById('add'),
    todoHolder = document.getElementById('todos-list'),
    showList = document.getElementById('show'),
    hideList = document.getElementById('hide'),
    removeButton = document.getElementById('remove');
todoText = '';

showList.addEventListener('click', showTodos);
hideList.addEventListener('click', hideTodos);
addButton.addEventListener('click', addTodo);
removeButton.addEventListener('click', removeTodo);
todo.addEventListener('change', getTodoText, false);

function getTodoText() {
    todoText = todo.value;
}

function addTodo() {
    todoDiv = document.createElement('div');

    todoDiv.className = 'todoString';
    todoDiv.innerText = todoText;

    if (todoHolder.firstChild) {
        todoHolder.insertBefore(todoDiv, todoHolder.firstChild);
    } else {
        todoHolder.appendChild(todoDiv);
    }

    todo.value = '';
}

function removeTodo() {
    if (todoHolder.firstChild) {
        todoHolder.removeChild(todoHolder.firstChild);
    }
}

function hideTodos() {
    var items = document.getElementsByClassName('todoString');
    for (var i = 0; i < items.length; i++) {
        console.log(items[i]);
        items[i].style.display = 'none';
    }
}

function showTodos() {
    var items = document.getElementsByClassName('todoString');
    for (var i = 0; i < items.length; i++) {
        console.log(items[i]);
        items[i].style.display = '';
    }
}