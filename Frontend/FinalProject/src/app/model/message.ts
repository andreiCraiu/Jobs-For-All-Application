import { Time } from "@angular/common";

export class Message {
    id!: number;
    content!: string;
    sendTime!: Date;
    senderId!: number;
    receiverId!: number;
}