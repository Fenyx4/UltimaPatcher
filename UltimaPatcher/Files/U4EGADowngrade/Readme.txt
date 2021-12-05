Ultima IV EGA to VGA patch by Natreg Dragon
===========================================


Introduction
============

This patch is intended for installations of Ultima IV using the "Ultima IV VGA upgrade patch". 
This patch overwrittes the VGA graphics with the old EGA graphics.

The old EGA graphics have been converted to VGA graphics, thus giving all the extras from Aradindae Dragon & Wiltshire Dragon patch while mantaining the old classic look.



Installation
============

You only need to copy the files from the patch overwritting the old VGA patch. Make sure to make backups of the files if you want to restore the original VGA graphics.

The patch can be applied to all files, or selectively. For instance, you may use the EGA tiles, but maintain all the cutscene graphics, or you may want only to change the font of the game and nothing else.



FILES
=====

charset.ega - Original font in EGA format.
charset.vga - Original font in VGA format.
shapes.vga - Original tiles in VGA format.
start.ega - Original interface in VGA format.
rune_0.ega - rune_8.EGA - Original shrines vision & riddle vision in VGA format.
Key7.ega - Oiriginal three part key cutscene in VGA format.
Stoncrcl.ega - Original ending image in VGA format.

Original Codex images in VGA format:
Compassn.ega
Courage.ega
Honesty.ega
Honor.ega
Humility.ega
Justice.ega
Love.ega
Sacrific.ega
Spirit.ega
Truth.ega
Valor.ega


Folder "PNG": This folder has all the original files used for the patch. The subfolder called "XOR" has modified Codex Images used in the patch. 
The original game used an "OR" in order to recreate the Codex symbols with their graphics, however, the VGA patch changes this into a "XOR" in order to create a more detailed image of the Codex symbol.
In order for this patch to work as intended, the original EGA images had to be modified acordingly.

Original game:
RUNE_0.EGA 	the meditation vision for valor
RUNE_1.EGA 	the meditation vision for honesty, justice, and honor
RUNE_2.EGA 	the meditation vision for compassion and sacrifice
RUNE_3.EGA 	the meditation vision for spirituality
RUNE_4.EGA 	the meditation vision for humility
RUNE_5.EGA 	displayed after answering the final riddle

VGA patch and this EGA to VGA patch:
RUNE_0.EGA 	displayed after answering the final riddle
RUNE_1.EGA 	the meditation vision for honesty
RUNE_2.EGA 	the meditation vision for compassion
RUNE_3.EGA 	the meditation vision for valor
RUNE_4.EGA 	the meditation vision for justice
RUNE_5.EGA 	the meditation vision for sacrifice
RUNE_6.EGA 	the meditation vision for honor
RUNE_7.EGA 	the meditation vision for spirituality
RUNE_8.EGA 	the meditation vision for humility


IMPORTANT
=========
Even though it's possible to install only some of the files, the Codex images should all be installed as a pack. If only one of them is installed, it will cause problems during the part of the game it's used.
The reason for this is that the images are all used to recreate the Codex symbol one at a time, and they won't work correctly unless using all the original VGA files, or all the VGA files in this patch.

This patch assumes you are using the avatar.exe file modified in the VGA patch. The modification for this file makes it possible to have different images for the Shrines visions. 
Originally there were only 5 images, and the patch added 3 more. The numbers of the images are not the same on the original version and on the VGA version.




THANKS TO:
==========
Aradindae Dragon & Wiltshire Dragon for creating the music patch and the VGA patch.
Xu4 developers for their incredible tools.
Richard Garriott and Origin for this great game.

