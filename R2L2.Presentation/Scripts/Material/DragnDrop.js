﻿function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.effectAllowed = 'copy';
    ev.dataTransfer.setData("text", ev.target.id);
    console.log(ev);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
    
}