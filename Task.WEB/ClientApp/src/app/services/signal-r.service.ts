import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { StockModel } from '../_interfaces/stockmodel.mode';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  //constructor
  constructor(private http: HttpClient  ){}
  
  //call stock endpoint
  public startHttpRequest = () =>{
    this.http.get('https://localhost:5001/api/Stock').subscribe(res=>{
      console.log(res);
    });
  }
    
}


