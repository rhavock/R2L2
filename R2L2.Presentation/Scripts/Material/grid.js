function init_table_list(e) {
    var l = $(e).closest("table").find("tr");

   for (var i = 0; i < l.length; i++) {
       if ("grid-detail" != l[i].className) 
           l[i].className = "grid-toggle";
       
       if ("table-row" == l[i].style.display)
           l[i].style.display = "";
    }


    e.className = "grid-detail-show";
    s = e.parentNode.rows;

    if(s.length !=e.rowIndex)
        s[1].style.display = "table-row";
};
