import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Jobs } from '../model/job';

@Injectable({
  providedIn: 'root'
})
export class JobsService {

  private baseApiUrl= `${environment.baseApiUrl}/jobs/addJob`;
  private baseApiUrlGetJobs= `${environment.baseApiUrl}/jobs/getJobs`;

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private httpClient: HttpClient) { }
  public getJobs(){
    return  this.httpClient.get<Jobs[]>(`${this.baseApiUrlGetJobs}`).subscribe(_ => {
      
    }, error => console.error(error));
  }
  public requestJob(jobReques: any){
    return this.httpClient.post<any>(`${this.baseApiUrl}`, jobReques, { headers: this.headers });
  }
}
