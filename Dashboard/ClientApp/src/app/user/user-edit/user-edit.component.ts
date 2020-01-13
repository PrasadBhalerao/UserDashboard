import { Component, Input, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserService } from '../user.service';
import { User } from '../models';

@Component({
  selector: 'dialog-box',
  templateUrl: './user-edit.component.html',
  providers: [UserService]
})
export class UserEditComponent {
  public user: User;
  constructor(public dialogRef: MatDialogRef<UserEditComponent>, @Inject(MAT_DIALOG_DATA) data: any) {
    this.user = data['userDetail'];
  }

  onNoClick(): void {
    this.dialogRef.close();
  }



}
