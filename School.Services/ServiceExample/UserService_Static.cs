using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.ServiceExample
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
    }



    public class UserService
    {
        //https://www.red-gate.com/simple-talk/development/dotnet-development/creating-asp-net-apps-with-react/

        private static List<User> users = new List<User>();
        private static int Count = 1;
        private static readonly string[] names = new string[] { "Jonathan", "Mary", "Susan", "Joe", "Paul", "Carl", "Amanda", "Neil" };
        private static readonly string[] surnames = new string[] { "Smith", "O'Neil", "MacDonald", "Gay", "Bailee", "Saigan", "Strip", "Spenser" };
        private static readonly string[] extensions = new string[] { "@gmail.com", "@hotmail.com", "@outlook.com", "@icloud.com", "@yahoo.com" };
        static UserService()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                string currName = names[rnd.Next(names.Length)];
                User user = new User
                {
                    Id = Count++,
                    Name = currName + " " + surnames[rnd.Next(surnames.Length)],
                    Email = currName.ToLower() + extensions[rnd.Next(extensions.Length)],
                    Document = (rnd.Next(0, 100000) * rnd.Next(0, 100000)).ToString().PadLeft(10, '0'),
                    Phone = "+1 888-452-1232"
                };
                users.Add(user);
            }
        }
        public List<User> GetAll()
        {
            return users;
        }
        public User GetById(int id)
        {
            return users.Where(user => user.Id == id).FirstOrDefault();
        }
        public User Create(User user)
        {
            user.Id = Count++;
            users.Add(user);
            return user;
        }
        public void Update(int id, User user)
        {
            User found = users.Where(n => n.Id == id).FirstOrDefault();
            found.Name = user.Name;
            found.Email = user.Email;
            found.Document = user.Document;
            found.Phone = user.Phone;
        }
        public void Delete(int id)
        {
            users.RemoveAll(n => n.Id == id);
        }
    }
}

/*

public JsonResult getEmployeeList(string sortColumnName = "FirstName", string sortOrder = "asc", int pageSize = 3, int currentPage = 1, string searchText = "")
{
    List<Employee> List = new List<Employee>();
    int totalPage = 0;
    int totalRecord = 0;
 
    using (MyDatabaseEntities dc = new MyDatabaseEntities())
    {
        var emp = dc.Employees.Select(a => a);
        //Search
        if (!string.IsNullOrEmpty(searchText))
        {
            emp = emp.Where(a => a.FirstName.Contains(searchText) || a.LastName.Contains(searchText) || a.EmailID.Contains(searchText) || a.City.Contains(searchText) || a.Country.Contains(searchText));
        }
        totalRecord = emp.Count();
        if (pageSize > 0)
        {
            totalPage = totalRecord / pageSize + ((totalRecord % pageSize) > 0 ? 1 : 0);
            List = emp.OrderBy(sortColumnName + " " + sortOrder).Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
        }
        else
        {
            List = emp.ToList();
        }
    }
 
    return new JsonResult
    {
        //Data = new { List = List, totalPage = totalPage, sortColumnName = sortColumnName, sortOrder = sortOrder, currentPage = currentPage},
        Data = new { List = List, totalPage = totalPage, sortColumnName = sortColumnName, sortOrder = sortOrder, currentPage = currentPage, pageSize = pageSize, searchText = searchText },
        JsonRequestBehavior = JsonRequestBehavior.AllowGet
    };
}

*/


/*
 
     import React, { Component } from 'react';
import { Table, Button } from 'reactstrap';
import RegistrationModal from './form/RegistrationModal';
import { USERS_API_URL } from '../constants';
class DataTable extends Component {
  deleteItem = id => {
    let confirmDeletion = window.confirm('Do you really wish to delete it?');
    if (confirmDeletion) {
      fetch(`${USERS_API_URL}/${id}`, {
        method: 'delete',
        headers: {
          'Content-Type': 'application/json'
        }
      })
        .then(res => {
          this.props.deleteItemFromState(id);
        })
        .catch(err => console.log(err));
    }
  }
  render() {
    const items = this.props.items;
    return <Table striped>
      <thead className="thead-dark">
        <tr>
          <th>Id</th>
          <th>Name</th>
          <th>Email</th>
          <th>Document</th>
          <th>Phone</th>
          <th style={{ textAlign: "center" }}>Actions</th>
        </tr>
      </thead>
      <tbody>
        {!items || items.length <= 0 ?
          <tr>
            <td colSpan="6" align="center"><b>No Users yet</b></td>
          </tr>
          : items.map(item => (
            <tr key={item.id}>
              <th scope="row">
                {item.id}
              </th>
              <td>
                {item.name}
              </td>
              <td>
                {item.email}
              </td>
              <td>
                {item.document}
              </td>
              <td>
                {item.phone}
              </td>
              <td align="center">
                <div>
                  <RegistrationModal
                    isNew={false}
                    user={item}
                    updateUserIntoState={this.props.updateState} />
                  &nbsp;&nbsp;&nbsp;
                  <Button color="danger" onClick={() => this.deleteItem(item.id)}>Delete</Button>
                </div>
              </td>
            </tr>
          ))}
      </tbody>
    </Table>;
  }
}
export default DataTable;
     
     */
