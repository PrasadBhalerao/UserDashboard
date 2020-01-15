import { Component, Input, Inject  } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
//import { MdInputDirective } from '@angular/material';
import { UserService } from '../user.service';
import { User } from '../models';

@Component({
  selector: 'dialog-box',
  templateUrl: './user-edit.component.html',
  providers: [UserService],
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent {
  public user: User;
  public roles: any[];
  public statuses: any[];
  //@ViewChild('input') input: MdInputDirective;

  constructor(public dialogRef: MatDialogRef<UserEditComponent>, @Inject(MAT_DIALOG_DATA) data: any, public userService: UserService) {
    this.user = data['userDetail'];
    if (this.user == null) {
      this.user = new User();
    }
    this.roles = [{ keyId: 1, name: 'Admin' }, { keyId: 2, name: 'Customer Executive' }];
    this.statuses = [{ keyId: 1, name: 'Active' }, { keyId: 2, name: 'Pending' }, { keyId: 3, name: 'Inactive' }];
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

  deleteUser(keyId: number) {
    this.userService.deleteUser(keyId).subscribe(() => {
      this.dialogRef.close();
    }, (errorResponse) => {
      alert('Error deleting user!');
    });
  }

  updateUser(user: User) {
    this.userService.updateUser(user).subscribe(() => {
      this.dialogRef.close();
    }, (errorResponse) => {
      alert('Error updating user!');
    });
  }


}
