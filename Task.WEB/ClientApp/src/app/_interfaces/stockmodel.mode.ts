
export interface StockModel{
    id:number,
    name: string,
    price: [],
}


export interface orderModel{
    stockId:number,
    stockName:string,
    price: number,
    quantity: number,
    commission: number,
    person:personModel,
    broker?:brokerModel,
}
export interface personModel{
    id:number,
    name: string,
    orderModel?: orderModel[],
}
export interface brokerModel{
    id:number,
    name: string,
    personModel?: personModel[],
    orderModel?: orderModel[],
}