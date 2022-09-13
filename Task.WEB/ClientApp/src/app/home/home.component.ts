import { Component, ChangeDetectorRef } from '@angular/core';
import { SignalRService } from './../services/signal-r.service';
import { StockModel, orderModel } from './../_interfaces/stockmodel.mode';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public Stocks : StockModel[];
  public order : orderModel;
  temp:any;
  constructor( public signalRService : SignalRService ,private http: HttpClient , private changeDetection: ChangeDetectorRef ){
  }
  bradcastedData:any;
  private hubConnection :signalR.HubConnection;
  ngOnInit(): void {
      //connect to hub url and build
      this.hubConnection =new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:5001/Stocks')
        .build();
      // start connection 
      this.hubConnection
        .start()
        .then(()=>console.log('connection starting'))
        .catch(err => console.log('Error While Starting connection' + err))
      // connect to transferStockData and get data
      this.hubConnection.on('transferStockData',(data)=>{

        this.Stocks = data;
        this.changeDetection.detectChanges();
        console.log(data);
      })  
      // call stock endpoint
      this.signalRService.startHttpRequest();
        
  }


  public stockClicked = (Stock) => {
    console.log(Stock);
    this.broadcastStockData(Stock);
    this.addBroadcastStockDataListener();
  }
  
  public broadcastStockData (Stock){
    
    this.temp = {
      id:Stock.id,
      name:Stock.name,
      price:Stock.price,

    }
  
    this.hubConnection.invoke('broadcastStockdata', this.temp)
    .catch(err => console.error(err));
  }
public addBroadcastStockDataListener = () => {
  this.hubConnection.on('broadcastStockdata', (data) => {
    this.bradcastedData = data;
    this.changeDetection.detectChanges();

    console.log(data);
  })
}
}
