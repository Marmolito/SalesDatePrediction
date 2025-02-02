import { Routes } from '@angular/router';
import { SalesDatePredictionViewComponent } from './Pages/sales-date-prediction-view/sales-date-prediction-view.component';
import { OrdersViewComponent } from './Pages/orders-view/orders-view.component';
import { NewOrderFormComponent } from './Pages/new-order-form/new-order-form.component';

export const routes: Routes = [

    {path:"",component:SalesDatePredictionViewComponent},
    {path:"inicio",component:SalesDatePredictionViewComponent},
    {path:"ordenes/:id",component:OrdersViewComponent},
    {path:"nueva-orden",component:NewOrderFormComponent},

];
