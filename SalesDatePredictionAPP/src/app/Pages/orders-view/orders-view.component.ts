import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { OrderService } from '../../Services/order.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-orders-view',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatIconModule],
  templateUrl: './orders-view.component.html',
  styleUrl: './orders-view.component.css'
})
export class OrdersViewComponent implements OnInit {

  customerId: number;
  orders: any[] = [];

  displayedColumns: string[] = ['orderId', 'requiredDate', 'skippedDate', 'shipName', 'shipAddress', 'shipCity'];

  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private dialogRef: MatDialogRef<OrdersViewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private orderService: OrderService) {
    this.customerId = data.customerId;
  }

  ngOnInit(): void {
    this.getOrdersByCustomerId();
    this.dataSource.data = this.orders;
  }

  getOrdersByCustomerId(): void {
    this.orderService.getOrderdersByCustomerId(this.customerId)
      .subscribe(
        (response) => {
          this.dataSource.data = response.data;
          this.dataSource.paginator = this.paginator;
          this.dataSource.sort = this.sort;
        }
      );
  }

  closeForm(): void {
    this.dialogRef.close();
  }

}
