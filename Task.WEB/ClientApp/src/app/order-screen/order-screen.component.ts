import { Component, OnInit ,ChangeDetectorRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SignalRService } from '../services/signal-r.service';
import { StockModel, orderModel } from '../_interfaces/stockmodel.mode';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-order-screen',
  templateUrl: './order-screen.component.html',
  styleUrls: ['./order-screen.component.css']
})
export class OrderScreenComponent implements OnInit {

  constructor( public signalRService : SignalRService ,private http: HttpClient , private changeDetection: ChangeDetectorRef){
  }
  private hubConnection :signalR.HubConnection;
  bradcastedData:orderModel;

  ngOnInit() {
        //connect to hub url and build
        this.hubConnection =new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:5001/Stocks')
        .build();
        // start connection 
        this.hubConnection
        .start()
        .then(()=>console.log('connection starting'))
        .catch(err => console.log('Error While Starting connection' + err))
    
        this.hubConnection.on('broadcastStockdata', (data) => {
          this.bradcastedData = data;
          this.changeDetection.detectChanges();
          
          console.log(data);
        });
    
  }

}
