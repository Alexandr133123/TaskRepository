import { Component } from "@angular/core";
import { DataService } from "../service/data-service";
import { OnInit } from "@angular/core";
import { User } from "../Models/User";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import {UsersCountResult} from "../Models/UsersCountResult";

@Component({

    selector: 'app-comp',
    templateUrl: '../html/appcomp.html',
    providers: [DataService]
})

export class AppComponent implements OnInit{


    users: User[];
    user: User;
    usersCount: UsersCountResult = new UsersCountResult();
   
    ngOnInit(){
        this.loadData();
    }


    constructor(private dataservice: DataService,public Modal: NgbModal){}

    open(content){
    
            this.Modal.open(content);
    }
   
    loadData(){
        this.dataservice.getUsers().subscribe((data: User[]) => this.users = data);
        this.dataservice.getCount().subscribe((data: UsersCountResult) => this.usersCount = data);
    }

  
    
    BoolChange(u: User){
        this.user = u;
        this.user.active = !this.user.active;
        this.dataservice.updateBool(this.user).subscribe(data => this.loadData());

    }

}
