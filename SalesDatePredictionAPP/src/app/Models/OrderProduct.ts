export interface OrderProduct {
    custID: number,
    empID: number,
    shipperID: number,
    shipName: string,
    shipAddress: string,
    shipCity: string,
    orderDate: string,
    requiredDate: string,
    shippedDate: string,
    freight: number ,
    shipCountry: string,

    productID: number,
    unitPrice: number ,
    qty: number,
    discount: number ,
}