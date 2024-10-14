// course.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenService } from 'abp-ng2-module';
import { AppConsts } from '../../../shared/AppConsts';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
  private apiUrl = `${AppConsts.remoteServiceBaseUrl}/api/services/app/Course/GetAll`;

  constructor(private http: HttpClient, private tokenService: TokenService) {}

  getCourses(): Observable<any> {
    const token = this.tokenService.getToken(); // Lấy token từ TokenService
    const requestHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}` // Thêm token vào headers
    });

    return this.http.get<any>(this.apiUrl, { headers: requestHeaders });
  }
}
