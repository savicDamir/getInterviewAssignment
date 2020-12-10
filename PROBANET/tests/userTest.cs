using Xunit;
using PROBANET.Controllers;
using PROBANET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class userTest
{
    [Fact]
    public void login()
    {
        var context=new pmdbContext();
        var user = context.Users.First();
        
        var user1 = new User();
        user1.Username= "DSavic";
        user1.Password= "1234";
        user1.Role= "Project Manager";
        user1.Name="name";
        user1.Surname="last";
        user1.Email="u@u";

        var obj = new HomeController();

        var result = obj.Login(user);

        var viewResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(220,viewResult.StatusCode);

        var result1 = obj.Login(user1);

        var viewResult1 = Assert.IsType<ObjectResult>(result1);
        Assert.Equal(210,viewResult1.StatusCode);

    }

    [Fact]
    public void insertUpdateDeleteUserTest()
    {
        var user = new User();
        user.Username= "MikaMikic";
        user.Password= "1234";
        user.Role= "Administrator";
        user.Name="name";
        user.Surname="last";
        user.Email="u@u";

        var obj = new AdminController();

        var result = obj.AddUser(user);

        var viewResult = Assert.IsType<StatusCodeResult>(result);//success add 
        Assert.Equal(200,viewResult.StatusCode);
        
        var result2= obj.AddUser(user);

        var viewResult2 = Assert.IsType<StatusCodeResult>(result2);//failed add
        Assert.Equal(210,viewResult2.StatusCode);

        

        //Assert.Equal(viewResult2.RouteValues["Action"],"Index");
        //Assert.Equal(viewResult2.RouteValues["Controller"],"Admin");
        var result3 = obj.DeleteUser(user); 

        var viewResult3 = Assert.IsType<StatusCodeResult>(result3); //success delete
        Assert.Equal(200,viewResult3.StatusCode);

        var result4 = obj.DeleteUser(user); 

        var viewResult4 = Assert.IsType<StatusCodeResult>(result4); //failed delete
        Assert.Equal(210,viewResult4.StatusCode);

    }

        [Fact]
    public void insertUpdateDeleteUserProject()
    {
        var project = new Project();
        project.Name= "testProject";
        project.Code= "testCode";
        

        var obj = new AdminController();

        var result = obj.AddProject(project);

        var viewResult = Assert.IsType<StatusCodeResult>(result);//success add 
        Assert.Equal(200,viewResult.StatusCode);
        
        var result2= obj.AddProject(project);

        var viewResult2 = Assert.IsType<StatusCodeResult>(result2);//failed add
        Assert.Equal(210,viewResult2.StatusCode);

        

        //Assert.Equal(viewResult2.RouteValues["Action"],"Index");
        //Assert.Equal(viewResult2.RouteValues["Controller"],"Admin");
        var result3 = obj.DeleteProject(project.Id); 

        var viewResult3 = Assert.IsType<StatusCodeResult>(result3); //success delete
        Assert.Equal(200,viewResult3.StatusCode);

        var result4 = obj.DeleteProject(project.Id); 

        var viewResult4 = Assert.IsType<StatusCodeResult>(result4); //failed delete
        Assert.Equal(210,viewResult4.StatusCode);

    }

    [Fact]
    public void insertUpdateDeleteUserTask()
    {
        var context=new pmdbContext();
        var task = new PROBANET.Models.Task();
        task.ProId= context.Projects.Select(p => p.Id).First();
        task.Progress=0;
        task.Status="New";
        task.Deadline=DateTime.Today;
        task.Description= "Description";

        

        var obj = new AdminController();

        var result = obj.AddTask(task);

        var viewResult = Assert.IsType<StatusCodeResult>(result);//success add 
        Assert.Equal(200,viewResult.StatusCode);
        
        var result2= obj.AddTask(task);

        var viewResult2 = Assert.IsType<StatusCodeResult>(result2);//failed add
        Assert.Equal(210,viewResult2.StatusCode);

        

        //Assert.Equal(viewResult2.RouteValues["Action"],"Index");
        //Assert.Equal(viewResult2.RouteValues["Controller"],"Admin");
        var result3 = obj.DeleteTask(task.Id); 

        var viewResult3 = Assert.IsType<StatusCodeResult>(result3); //success delete
        Assert.Equal(200,viewResult3.StatusCode);

        var result4 = obj.DeleteTask(task.Id); 

        var viewResult4 = Assert.IsType<StatusCodeResult>(result4); //failed delete
        Assert.Equal(210,viewResult4.StatusCode);

    }


}