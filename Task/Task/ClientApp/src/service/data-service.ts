import { Injectable } from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {User} from "../User";
import { count } from "console";


@Injectable()
export class DataService{

     private url = "/api/users";

     constructor(private http : HttpClient){}

     getUsers(){
         return this.http.get(this.url + "/data");
     }
     
     getCount(){
         return this.http.get(this.url + "/count");
     }

     updateBool(user: User ){
         return this.http.put(this.url, user);
     }
    
}