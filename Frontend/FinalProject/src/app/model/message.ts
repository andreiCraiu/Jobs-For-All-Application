import { Time } from "@angular/common";

export class Message {
    id!: number;
    content!: string;
    sendTime!: Date;
    senderId!: any;
    receiverId!: string;
    chatId!: number;
    messageAuthor: string;
}