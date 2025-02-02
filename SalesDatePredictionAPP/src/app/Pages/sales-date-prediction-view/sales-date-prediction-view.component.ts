import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { OrdersViewComponent } from '../orders-view/orders-view.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { CustomerService } from '../../Services/customer.service';
import { NewOrderFormComponent } from '../new-order-form/new-order-form.component';

@Component({
  selector: 'app-sales-date-prediction-view',
  templateUrl: './sales-date-prediction-view.component.html',
  styleUrl: './sales-date-prediction-view.component.css',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatIconModule,
  ]
})
export class SalesDatePredictionViewComponent implements OnInit{

  displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrderDate', 'actions'];
  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private customerService: CustomerService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.customerService.getCustomers().subscribe(
      (response) => {
      this.dataSource.data = response.data;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  viewOrders(customer: any): void {
    console.log('customerId antes de abrir el modal:', customer.custid);
    this.dialog.open(OrdersViewComponent, {
      width: '800px',
      data: { customerId: customer.custid }
    });
  }

  createOrder(customer: any): void {
    this.dialog.open(NewOrderFormComponent, {
      width: '800px',
      data: { customerId: customer.custid }
    });
  }

}
