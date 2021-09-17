import { Component } from "@angular/core";
import { DataService } from "../service/data-service";
import { OnInit } from "@angular/core";
import { User } from "../User";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({

    selector: 'app-comp',
    templateUrl: '../html/appcomp.html',
    providers: [DataService]
})

export class AppComponent implements OnInit{

    users: User[];
    user: User;
    TotalCount: number = 0;
    ActiveCount: number = 0;
    ngOnInit(){
        this.loadUsers();
    
    }

    setCount(){
        if(this.users!=undefined){
          this.TotalCount= this.users.length;
            this.users.forEach(u => {
                if(u.active){
                 this.ActiveCount++;
                 }
            });
        }
    }

    constructor(private dataservice: DataService,public Modal: NgbModal){}

    open(content){
            this.setCount();
            this.Modal.open(content);
    }
   
    loadUsers(){
        this.dataservice.getUsers().subscribe((data: User[])=> this.users = data);
    }
    
    BoolChange(u: User){
        this.user = u;
        this.user.active = !this.user.active;
        this.dataservice.updateBool(this.user).subscribe(data => this.loadUsers());

    }

}
