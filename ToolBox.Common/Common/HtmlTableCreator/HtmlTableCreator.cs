using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Common.Common.HtmlTableCreator
{
    class HtmlTableCreator
    {


    }
}

//public boolean onDeleteClick()
//{
//    Integer id = deleteLink.getValueInteger();
//    getCustomerService().deleteCustomer(id);
//    return true;
//} 


/*
https://www.newline.co/@dmitryrogozhny/how-to-show-data-grids-with-bootstrap-theming-in-react-with-react-bootstrap-table--a0e05f52

import React from "react";

import "bootstrap/dist/css/bootstrap.css";
import "react-bootstrap-table-next/dist/react-bootstrap-table2.min.css";

import BootstrapTable from "react-bootstrap-table-next";

const products = [
  { id: 0, name: "Item name 0", price: 2100 },
  { id: 1, name: "Item name 1", price: 2101 },
  { id: 2, name: "Item name 2", price: 2102 },
  { id: 3, name: "Item name 3", price: 2103 }
];

const columns = [
  {
    dataField: "id",
    text: "Product ID",
    sort: true
  },
  {
    dataField: "name",
    text: "Product Name",
    sort: true
  },
  {
    dataField: "price",
    text: "Product Price"
  }
];

export default function App()
{
    return (
  
      < div className = "App" >
   
         < BootstrapTable
        bootstrap4
        keyField = "id"
        data ={ products}
    columns ={ columns}
      />
    </ div >
  );
}



 
     
     
     
     
 import React from "react";

import "bootstrap/dist/css/bootstrap.css";
import "react-bootstrap-table-next/dist/react-bootstrap-table2.min.css";

import BootstrapTable from "react-bootstrap-table-next";
import paginationFactory from "react-bootstrap-table2-paginator";

export const productsGenerator = quantity => {
  const items = [];
  for (let i = 0; i < quantity; i++) {
    items.push({ id: i, name: `Item name ${i}`, price: 2100 + i });
  }
  return items;
};

const products = productsGenerator(100);

const columns = [...];

export default function App() {
  return (
    <div className="App">
      <BootstrapTable
        bootstrap4
        keyField="id"
        data={products}
        columns={columns}
        pagination={paginationFactory({ sizePerPage: 5 })}
      />
    </div>
  );
}    
     
     
     
     
     
     
     */






