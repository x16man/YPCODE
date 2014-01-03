var pressingShift = false;
var pressingCtrl = false;

document.onkeydown = function(e) {
    e = e ? e : window.event;
    if (e.keyCode == 16) { //Shift Key 
        pressingShift = true;
    }
    else if (e.keyCode == 17) { //Ctrl Key
        pressingCtrl = true;
    }
};
document.onkeyup = function(e) {
    e = e ? e : window.event;
    if (e.keyCode == 16) { //Shift Key
        pressingShift = false;
    }
    else if (e.keyCode == 17) {//Ctrl Key
        pressingCtrl = false;
    }
};
//DataGrid Row Item Object.
function ClassDataGridItem(ID, row) {
    this.ID = ID;
    this.row = row;
}
//DataGrid JS Object.
function DataGridObject(dg, isMultiSelect,hoverCSS, selectedCSS) {
    if (dg != null) {
        this.DataGrid = dg;
        //public
        this.MultiSelect = isMultiSelect;
        this.HighLightCSS = hoverCSS;
        this.SelectedCSS = selectedCSS;
        //private
        this.dgHoverItem = null;
        this.dgSelectedItem = null;
        this.MultiSelectedItems = [];
        this.tbSelectedID = document.getElementById(dg.id + "_SelectedID");
        this.tbSelectedArray = document.getElementById(dg.id + "_SelectedArray");
        this.tbSelectedStream = document.getElementById(dg.id + "_SelectedStream");

        this.SelectedID = this.tbSelectedID.value;
        this.SelectedArray = this.tbSelectedArray.value;


        this.Init = function() {
            if (this.SelectedID != "" && this.SelectedID != null)//single row selection mode,and one row is selected.
            {
                for (i = 0; i < this.DataGrid.rows.length; i++) {
                    if (this.DataGrid.rows[i].id == this.SelectedID) {
                        this.dgSelectedItem = new ClassDataGridItem(this.SelectedID, i);
                    }
                }
            }
            if (this.SelectedArray != "" && this.SelectedArray != null)//
            {
                var SA = this.SelectedArray.split(",");
                for (i = 0; i < SA.length; i++) {
                    this.SelectRowByID(SA[i]);
                }
            }
        };
        this.DataGrid.onselectstart = function() {
            return false;
        };
        this.getSelectedID = function() {
            return this.dgSelectedItem == null ? "" : this.dgSelectedItem.ID;
        };
        this.getSelectedArray = function() {
            if (this.MultiSelect) {
                var SelectedArray = [];
                for (i = 0; i < this.MultiSelectedItems.length; i++) {
                    if (this.MultiSelectedItems[i] != null) {
                        SelectedArray[SelectedArray.length] = this.MultiSelectedItems[i].ID;
                    }
                }
                return SelectedArray;
            }
            else {
                return this.getSelectedID();
            }
        };
        this.getSelectedStream = function() {
            if (this.MultiSelect) {
                var SelectedStream = [];
                for (i = 0; i < this.MultiSelectedItems.length; i++) {
                    if (this.MultiSelectedItems[i] != null) {
                        SelectedStream[SelectedStream.length] = "'" + this.MultiSelectedItems[i].ID + "'";
                    }
                }
                return SelectedStream;
            }
            else {
                return "'" + this.getSelectedID() + "'";
            }
        };
        this.execMouseOver = function(row) {
            this.dgHoverItem = new ClassDataGridItem(row.id, row.rowIndex);
            addClass(row, this.HighLightCSS);
        };
        this.execMouseOut = function(row) {
            removeClass(row, this.HighLightCSS);
        };
        this.execClick = function(obj) {
            if (!pressingShift) {
                if (pressingCtrl) {
                    this.toggleObj(obj);
                }
                else {
                    if (this.MultiSelectedItems[obj.rowIndex] != null) {
                        for (i = 0; i < this.MultiSelectedItems.length; i++) {
                            if (this.MultiSelectedItems[i] != null) {
                                removeClass(this.DataGrid.rows[i], this.SelectedCSS);
                                this.MultiSelectedItems[i] = null;
                            }
                        }
                        this.SelectObj(obj);
                    }
                }
            }
        };
        this.execMouseDown = function(obj) {
            if (this.MultiSelect) {
                if (!pressingCtrl) {
                    if (this.MultiSelectedItems[obj.rowIndex] == null || pressingShift) {
                        for (i = 0; i < this.MultiSelectedItems.length; i++) {
                            if (this.MultiSelectedItems[i] != null)//The row was selected,then unselect it.
                            {
                                removeClass(this.DataGrid.rows[i], this.SelectedCSS);
                                this.MultiSelectedItems[i] = null;
                            }
                        }
                    }
                }
                if (pressingShift) {
                    var startRow;
                    var endRow;
                    if (this.dgSelectedItem == null) {
                        this.dgSelectedItem = new ClassDataGridItem(obj.id, obj.rowIndex);
                    }
                    if (this.dgSelectedItem.row > obj.rowIndex) {
                        startRow = obj.rowIndex;
                        endRow = this.dgSelectedItem.row;
                    }
                    else {
                        startRow = this.dgSelectedItem.row;
                        endRow = obj.rowIndex;
                    }
                    for (i = startRow; i <= endRow; i++) {
                        this.MultiSelectedItems[i] = new ClassDataGridItem(this.DataGrid.rows[i].id, i);
                        addClass(this.DataGrid.rows[i], this.SelectedCSS);
                    }
                }
                else {
                    if (this.MultiSelectedItems[obj.rowIndex] == null) {
                        if (!pressingCtrl) {
                            this.SelectObj(obj);
                        }
                    }
                }
            }
            else {
                if (this.dgSelectedItem == null) {
                    this.dgSelectedItem = new ClassDataGridItem(obj.id, obj.rowIndex);
                }
                else {
                    if (this.dgSelectedItem.row != obj.rowIndex) {
                        removeClass(this.DataGrid.rows[this.dgSelectedItem.row], this.SelectedCSS);
                        this.dgSelectedItem = new ClassDataGridItem(obj.id, obj.rowIndex);
                    }
                }
                addClass(obj, this.SelectedCSS);
            }
        };
        this.SelectObj = function(obj) {
            this.MultiSelectedItems[obj.rowIndex] = new ClassDataGridItem(obj.id, obj.rowIndex);
            this.dgSelectedItem = this.MultiSelectedItems[obj.rowIndex];
            addClass(obj, this.SelectedCSS);
        };
        this.UnSelectObj = function(obj) {
            removeClass(obj, this.SelectedCSS);
            this.MultiSelectedItems[obj.rowIndex] = null;
        };
        this.toggleObj = function(obj) {
            if (hasClass(obj, this.SelectedCSS)) {
                this.UnSelectObj(obj);
            }
            else {
                this.SelectObj(obj);
            }
        };
        this.SelectRowByID = function(id) {
            for (j = 0; j < this.DataGrid.rows.length; j++) {
                if (this.DataGrid.rows[j].id == id) {
                    this.MultiSelectedItems[j] = new ClassDataGridItem(id, j);
                    addClass(this.DataGrid.rows[j], this.SelectedCSS);
                    return;
                }
            }
        };
        this.setSelectedID = function() { this.tbSelectedID.value = this.getSelectedID(); };
        this.setSelectedArray = function() { this.tbSelectedArray.value = this.getSelectedArray(); };
        this.setSelectedStream = function() { this.tbSelectedStream.value = this.getSelectedStream(); };

        this.Init();
    }
}
