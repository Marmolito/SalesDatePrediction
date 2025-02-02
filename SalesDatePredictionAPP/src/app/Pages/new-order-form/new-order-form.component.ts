import { Component, Inject, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../../Services/employee.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';


import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { OrderProduct } from '../../Models/OrderProduct';
import { OrderService } from '../../Services/order.service';
import { ProductService } from '../../Services/product.service';
import { ShipperService } from '../../Services/shipper.service'; // Importa el validador
import { dateValidator } from '../../Validators/custom.validators';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-new-order-form',
  standalone: true,
  imports: [
    CommonModule,
    MatDatepickerModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule,
    ReactiveFormsModule,
    MatNativeDateModule],
  templateUrl: './new-order-form.component.html',
  styleUrl: './new-order-form.component.css'
})
export class NewOrderFormComponent {

  orderForm!: FormGroup;
  dataSource = new MatTableDataSource<OrderProduct>([]);

  customerId: number;
  employees: any[] = [];
  shippers: any[] = [];
  products: any[] = [];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private dialogRef: MatDialogRef<NewOrderFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private orderService: OrderService,
    private employeeService: EmployeeService,
    private shipperService: ShipperService,
    private productService: ProductService,
  ) {
    this.customerId = data.customerId;
  }

  ngOnInit(): void {
    this.orderForm = this.fb.group({
      employee: ['', Validators.required],
      shipper: ['', Validators.required],
      shipName: ['', [Validators.required, Validators.maxLength(40)]],
      shipAddress: ['', [Validators.required, Validators.maxLength(60)]],
      shipCity: ['', [Validators.required, Validators.maxLength(15)]],
      shipCountry: ['', [Validators.required, Validators.maxLength(15)]],
      orderDate: ['', Validators.required],
      requiredDate: ['', Validators.required],
      shippedDate: ['', Validators.required],
      freight: ['', [Validators.required, Validators.min(0)]],
      product: ['', Validators.required],
      unitPrice: ['', [Validators.required, Validators.min(0)]],
      quantity: ['', [Validators.required, Validators.min(1)]],
      discount: ['', [Validators.required, Validators.min(0), Validators.max(1)]],
    }), { validators: dateValidator };;

    this.loadDropdownData();

    console.log(this.products[0])
  }

  loadDropdownData(): void {
    this.employeeService.getEmployees().subscribe(response => {
      this.employees = response.data;
    });

    this.shipperService.getShippers().subscribe(response => {
      this.shippers = response.data;
    });

    this.productService.getProducts().subscribe(response => {
      this.products = response.data;
    });
  }

  saveOrder(): void {
    if (this.orderForm.valid) {
      this.orderService.createOrderderProduct(this.mapFormToOrderProduct()).subscribe(
        response => console.log('Formulario Guardado:', response),
        error => console.error('Error Guardando Formulario:', error)
      );
      this.closeForm()
    } else {
      console.log('Formulario no válido');
    }
  }

  closeForm(): void {
    console.log('Form closed', ' ', this.customerId, ' ', this.orderForm.get('employee')?.value);
    this.dialogRef.close();
  }

  mapFormToOrderProduct(): OrderProduct {
    const formValues = this.orderForm.value;

    const orderProduct: OrderProduct = {
      custID: this.customerId,
      empID: formValues.employee,
      shipperID: formValues.shipper,
      shipName: formValues.shipName,
      shipAddress: formValues.shipAddress,
      shipCity: formValues.shipCity,
      shipCountry: formValues.shipCountry,
      orderDate: formValues.orderDate,
      requiredDate: formValues.requiredDate,
      shippedDate: formValues.shippedDate,
      freight: formValues.freight,
      productID: formValues.product,
      unitPrice: formValues.unitPrice,
      qty: formValues.quantity,
      discount: formValues.discount
    };

    return orderProduct;
  }
  

}
