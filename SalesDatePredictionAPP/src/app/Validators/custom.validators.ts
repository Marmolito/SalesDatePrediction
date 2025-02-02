import { AbstractControl, ValidationErrors } from '@angular/forms';

// Función para validar que la fecha de requiredDate no sea anterior a orderDate
export function dateValidator(control: AbstractControl): ValidationErrors | null {
  const orderDate = control.get('orderDate')?.value;
  const requiredDate = control.get('requiredDate')?.value;
  
  // Verifica si requiredDate es anterior a orderDate
  return requiredDate && orderDate && new Date(requiredDate) < new Date(orderDate)
    ? { 'dateInvalid': true } // Retorna un error si la validación falla
    : null;
}