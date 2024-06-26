using System;
using System.Collections.Generic;
using System.Text;



namespace PortSIP
{
    public class Session
    {
        private int mSessionId = 0;
        private bool mHoldState = false;
        private bool mSessionState = false;
        private bool mRecvCallState = false;
        private int mOriginCallSessionId = 0;
        private bool mIsReferCall = false;
        private bool mHasEarlyMedia = false;
        private int mDialogMessageId = 0;
        private int mOutOfDialogMessageId = 0;
        private bool mExistsAudio = false;
        private bool mExistsVideo = false;
        private bool mExistsScreen = false;
        private bool mInitiateScreen = false;
        public bool hasEarlyMedia()
        {
            return mHasEarlyMedia;
        }
        public void setEarlyMeida(bool earlyMedia)
        {
            mHasEarlyMedia = earlyMedia;
        }

        public bool isReferCall()
        { 
            return mIsReferCall; 
        }

        public int getOriginCallSessionId() 
        { 
            return mOriginCallSessionId; 
        }

        public void setReferCall(bool referCall, int originCallSessionId)
        {
            mIsReferCall = referCall;
            mOriginCallSessionId = originCallSessionId;
        }

        public void setDialogMessageId(int id)
        {
            mDialogMessageId = id;
        }

        public int getDialogMessageId()
        {
            return mDialogMessageId;
        }

        public void setOutOfDialogMessageId(int id)
        {
            mOutOfDialogMessageId = id;
        }

        public int getOutOfDialogMessageId()
        {
            return mOutOfDialogMessageId;
        }


        public bool getExistsVideo()
        {
            return mExistsVideo;
        }


        public void setExistsVide1o(bool state)
        {
            mExistsVideo = state;
        }

        public bool getExistsScreen()
        {
            return mExistsScreen;
        }


        public void setExistsScreen(bool state)
        {
            mExistsScreen = state;
        }

        public bool getExistsAudio()
        {
            return mExistsAudio;
        }

        public void setExistsAudio(bool state)
        {
            mExistsAudio = state;
        }

        public bool getInitiateScreen()
        {
            return mInitiateScreen;
        }

        public void setInitiateScreen(bool state)
        {
            mInitiateScreen = state;
        }
        public void reset()
        {
            mSessionId = 0;
            mHoldState = false;
            mSessionState = false;
            mRecvCallState = false;
            mOriginCallSessionId = 0;
            mIsReferCall = false;
            mDialogMessageId = 0;
            mOutOfDialogMessageId = 0;
            mExistsAudio = false;
            mExistsVideo = false;
            mExistsScreen = false;
            mInitiateScreen = false;
        }


        public void setSessionId(int sessionId)
        {
            mSessionId = sessionId;
        }


        public int getSessionId()
        {
            return mSessionId;
        }

        public void setHoldState(bool state)
        {
            mHoldState = state;
        }


        public bool getHoldState()
        {
            return mHoldState;
        }

        public void setSessionState(bool state)
        {
            mSessionState = state;
        }


        public bool getSessionState()
        {
            return mSessionState;
        }



        public void setRecvCallState(bool state)
        {
            mRecvCallState = state;
        }


        public bool getRecvCallState()
        {
            return mRecvCallState;
        }

    }
}
