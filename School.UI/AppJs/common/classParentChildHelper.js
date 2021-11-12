

var classParentChildHelper = {

    getChildIndex: function (child) {
        var parent = child.parentNode;
        var children = parent.children;

        var index = 0;
        for (var i = 0; i < children.length; i++) {
            if (child === children[i]) {
                index = i;
                break;
            }
        }

        return index;
    }
    , getChildIndexByUniqueID : function (child) {
        var parent = child.parentNode;
        var children = parent.children;

        var index = 0;
        for (var i = 0; i < children.length; i++) {
            if (child.uniqueID === children[i].uniqueID ) {
                index = i;
                break;
            }
        }

        return index;
    }
    ,
    getChildIndexAny: function (child, parentNumber) {

        parentNumber = parentNumber - 1;
        var parent = null;
        parent = child.parentNode;
        for (var i = 0; i < parentNumber; i++) {
            parent = parent.parentNode;
        }
        var children = parent.children;

        var index = 0;
        for (var j = 0; j < children.length; j++) {
            if (child === children[j]) {
                index = j;
                break;
            }
        }

        return index;
    }
    ,
    getParentByChild: function (child) {

        function isDescendant(parent, child) {
            var node = child.parentNode;
            while (node !== null) {
                if (node === parent) {
                    return true;
                }
                node = node.parentNode;
            }
            return false;
        }

        return isDescendant;
    }
    ,
    getParentByChild1: function (child) {

        function isDescendant(parent, child) {
            var node = child.parentNode;
            while (node !== null) {
                if (node === parent) {
                    return true;
                }
                node = node.parentNode;
            }
            return false;
        }

        return isDescendant;
    }
    ,
    isDescendant: function (el, parentId) {

            let isChild = false;

            if (el.id === parentId) { //is this the element itself?
                isChild = true;
            }

            while (el === el.parentNode) {
                if (el.id === parentId) {
                    isChild = true;
                }
            }

            return isChild;
     
    }
    ,
    removeChild: function (child, parentNumber) {

        /*
        <ul id="menu">
            <li>Home</li>
            <li>Products</li>
            <li>About Us</li>
        </ul>
        */
        let childNode = parentNode.removeChild(childNode);
        let menu = document.getElementById('menu');
        menu.removeChild(menu.lastElementChild);

        let menu1 = document.getElementById('menu');
        while (menu1.firstChild) {
            menu1.removeChild(menu.firstChild);
        }

        let top = document.getElementById("top");
        let nested = document.getElementById("nested");

        // This first call correctly removes the node
        let garbage = top.removeChild(nested);
    }
};


function sp_removeLastChildIfLineBreak(node) {
    var lastChild = node.lastChild;
    if (lastChild && sp_isLineBreak(lastChild)) {
        lastChild.parentNode.removeChild(lastChild);
    }
}

function sp_isLineBreak(node) {
    return node.nodeName === "BR";
}