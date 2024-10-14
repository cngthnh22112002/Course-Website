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
  private courseDetailUrl = `${AppConsts.remoteServiceBaseUrl}/api/services/app/Course/Get`; // Add endpoint for course details

  constructor(private http: HttpClient, private tokenService: TokenService) {}

  getCourses(): Observable<any> {
    const token = this.tokenService.getToken();
    const requestHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.get<any>(this.apiUrl, { headers: requestHeaders });
  }

  getCourseDetails(courseId: string): Observable<any> {
    const token = this.tokenService.getToken(); 
    const requestHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}` 
    });
    return this.http.get<any>(`${this.courseDetailUrl}?id=${courseId}`, { headers: requestHeaders });
  }
}
