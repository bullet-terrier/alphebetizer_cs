# 
# Modification By: Benjamin Tiernan
# Modification Date: 2017/02/28
# Modification Contents: Removed the radio buttons for determining file type,
#                        Should accept all ACH files regardless of origin.
#

# 6/09/2017 -- Changing the label information to display the file prefix rather than a meta description.
# 7/14/2017 -- Looking at adding verbose initialization in the shell.

#rvdate = '2017-02-28' # revision date. This only shows up on the UI side.
#rvdate = '2017-05-23'  # revision
#rvdate = '2017-06-09' # revision
rvdate = '2017-07-14'
print('''
Revision dates:\r\n
2017-02-28\r\n
2017-05-23\r\n
2017-06-09\r\n
2017-07-14\r\n
2018-03-12\r\n
''')
import os
import re
import gc
import sys
import subprocess
import tkinter as tk
from tkinter import filedialog as fd
from tkinter import messagebox as mb
from datetime import datetime as dt



# local libs:
pths = [".",".\\dependencies",".\\config",".\\support"]

# Here is the custom support file, think of it as a header.
from CORRECT_ACH_SUP import *

# The UI should basically remain unchanged between programs.
# I've updated the UI to 
class UI:
    # Reconfigured some of the configuration options
    # to handle ACH files.
    '''Support for a lightweight user interface.'''
    # designing the UI as a reusable piece now
    def __init__( self, master, func = None):
        '''initialize these values at launch'''
        print('initializing values')
        self.filename = tk.StringVar()
        self.filetype = tk.IntVar()
        self.file_opt = options = {}
        self.master = master
        options ['defaultextension'] = '.ACH'
        options ['filetypes'] = [('ACH files', '.ACH')]
        options ['initialdir'] = '.'
        options ['initialfile'] = '*.ACH'
        options ['parent'] = master
        self.resendUI( master )
        
    def quitButton( self ):
        showInfo(1, "QUIT", "EXITING PROGRAM")
        val = gc.collect()
        print( 0, "GARBAGE", "unreachable objects = %d" %(val))
        self.master.destroy()
    
    def browseButton( self ):
        '''Function to execute when the user wants to browse for a file.'''
        dtap = fd.askopenfilename() # only allows one file at a time.
        self.filename.set(dtap)
        print('opened file: %s'%(dtap))

    def submitButton( self ):
        ''' EXECUTE THE CORRECTION LOGIC'''
        '''Function to execute when the user selects the 'Submit' button. '''
        try:
            print(self.filetype.get())
            self.submitFunction(self.filename.get(), self.filetype.get(),True)#, grabfilename = self.filename.get(), _quiet = _quiet)
        except Exception as e:
                showInfo(1, "WARNING", "Exception:\n%s"%(e))
        finally:
            None
        #self.CorrectFileFunction()           

    def resendUI( self, master ):
        '''Graphical elements of the UI '''        
        print('loading graphical elements')
        self.loadLabel = tk.Label(
            master,
            text = "Select the file: "
            ).grid(
                row = 0,
                column = 0,
                columnspan = 3,
                pady = 5,
                padx = 5,
                stick = "W"
                )
        #setting the columnspan to stretch further to the left.
        self.fileinputEntryBox = tk.Entry(
            master,
            textvariable = self.filename,
            width = 90
            ).grid(
                row = 1,
                column = 0,
                columnspan = 3,
                pady = 5,
                padx = 5
                )
        self.browsebutton = tk.Button(
            master,
            text = "Browse",
            command = lambda:self.browseButton(),
            width = 10
            ).grid(
                row = 1,
                column = 3,
                pady = 5,
                padx = 5
                )
        self.testingBedSubmitButton = tk.Button(
            master,
            text = "Submit",
            command = lambda:self.submitButton(),
            fg = "White",
            bg = "Green",
            width = 10
            ).grid(
                row = 2,
                column = 3,
                pady = 5,
                padx = 5
                )
        self.QuitButton = tk.Button(
            master,
            text = "QUIT",
            command = lambda:self.quitButton(),
            bg = "Red",
            fg = "White",
            width = 10
            ).grid(
                row = 3,
                column = 3,
                pady = 5,
                padx = 5
                )
        self.describeLabel = tk.Label(
            master,
            text = "Correct ACH File Routing Numbers\nRevision date: %s\nWritten in Python 3.4\n\n-Benji Tiernan\nCurrent Date: %s"%(rvdate,dt.today().strftime('%Y-%m-%d'))
            ).grid(
                row = 2,
                column = 0,
                columnspan = 2,
                rowspan = 10, # changed rowspan from 6 to 10 to accomodate more text.
                pady = 5,
                padx = 5,
                stick = "W"
                )
        self.radiobuttonLabel = tk.Label(
        master,text="Choose the one that best matches the filename:").grid(row=2,column=2,columnspan=1,rowspan=1,pady=3,padx=5,stick="S")
        # Benjamin Tiernan --> Suppressing the radio buttons from appearing and defaulting the value to 1.
        # Can't quite do this yet, it still has some components that require the selection of a file type.
        #self.filetype.set(1)
        self.ftypeRadioButton1 = tk.Radiobutton(
            master,
            #text = "EFT",
            text = "UC Bank_en-US_1_###_YYYY_MM_DD_00-30-##.Debit.ACH",
            variable = self.filetype,
            value = 1,
            command = lambda:self.filetype.set(1)
            ).grid(
                row = 3,
                column = 2,
                columnspan = 1,
                rowspan = 1,
                pady = 3,
                padx = 5,
                stick = "W"
                )
        self.ftypeRadioButton2 = tk.Radiobutton(
            master,
            #text = "SWEEP",
            text = "Agency-BatchYYY-MM-DDT01-00-##.ACH",
            variable = self.filetype,
            value = 2,
            command = lambda:self.filetype.set(2)
            ).grid(
                row = 4,
                column = 2,
                columnspan = 1,
                rowspan = 1,
                pady = 3,
                padx = 5,
                stick = "W"
                )
#
# Additional Module Level Functions/Routines.
#
if __name__=="__main__":
    pass
else:
    print("imported %s as module"%(__name__))