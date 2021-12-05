code	segment	'code'
	assume	cs:code,ds:code

	org	100h

start:	mov	sp,01feh		; move stack pointer

	mov	bx,20h			; resize memory block
	mov	ah,4ah
	int	21h

	mov	ax,3510h		; get current INT 10h handler
	int	21h
	mov	word ptr old10,bx
	mov	word ptr old10+2,es
	push	cs			; restore ES for EXEC
	pop	es

	mov	dx,offset new10		; install new INT 10h handler
	mov	ax,2510h
	int	21h

	mov	word ptr tail+2,cs	; set param block segments
	mov	word ptr fcb1+2,cs
	mov	word ptr fcb2+2,cs

	mov	dx,offset prog		; EXEC child process
	mov	bx,offset parm
	mov	ax,4b00h
	int	21h

	mov	dx,word ptr old10	; restore previous INT 10h handler
	mov	ds,word ptr old10+2
	mov	ax,2510h
	int	21h

	mov	ax,4c00h		; exit to DOS
	int	21h

new10:	cmp	ah,06h			; scroll window up function?
	je	scroll
	cmp	ah,07h			; scroll window down function?
	je	scroll
	cmp	ah,12h			; alternate function?
	jne	exit

	push	bp
	mov	bp,sp
	push	ax
	push	si
	push	ds
	mov	ax,[bp+4]		; get caller's CS
	add	ax,0799h		; relative segment
	mov	ds,ax
	mov	si,0049h		; instruction offset
	cmp	word ptr [si],0d98eh	; mov ds,cx instruction?
	jne	pass
	mov	word ptr [si],01f0eh	; change to push cs/pop ds
pass:	pop	ds
	pop	si
	pop	ax
	pop	bp
	jmp	exit

scroll:	push	ax
	push	dx
	mov	dx,03dah
wait0:	in	al,dx			; wait until out of retrace
	test	al,8
	jne	wait0
wait1:	in	al,dx			; wait for leading edge of retrace
	test	al,8
	je	wait1
	pop	dx
	pop	ax
exit:
	db	0eah			; far jump opcode
old10	dd	0			; old INT 10h handler address

prog	db	'ULTIMA7.COM',0		; program filename

parm	dw	0			; default env seg
tail	dd	80h			; command line tail pointer
fcb1	dd	5ch			; first FCB pointer
fcb2	dd	6ch			; second FCB pointer

code	ends

	end	start
