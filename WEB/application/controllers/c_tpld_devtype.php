<?php
	 class C_tpld_devtype extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_DEVTYPE.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_DEVTYPE.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_devtypeid' =>  $this->input->get_post('tpld_devtypeid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'devclass' =>   $this->input->get_post('devclass', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'driverlibname' =>   $this->input->get_post('driverlibname', TRUE)
            );
            $tpld_devtype = $this->m_tpld_devtype->setRow($data);
            print json_encode($tpld_devtype);
    }
    function newRow() {
            log_message('debug', 'TPLD_DEVTYPE.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_devtypeid' =>  $this->input->get_post('tpld_devtypeid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'devclass' =>   $this->input->get_post('devclass', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'driverlibname' =>   $this->input->get_post('driverlibname', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_devtype= $this->m_tpld_devtype->newRow($instanceid,$data);
            $return = $tpld_devtype;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_DEVTYPE.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_devtype = $this->m_tpld_devtype->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_devtype
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'devclass', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpld_devtype= $this->m_tpld_devtype->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_devtype= $this->m_tpld_devtype->getRows($sort);
                }
            }else{
              $tpld_devtype= $this->m_tpld_devtype->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_devtype
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_DEVTYPE.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'devclass', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpld_devtype= $this->m_tpld_devtype->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_devtype
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLD_DEVTYPE.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'devclass', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpld_devtype= $this->m_tpld_devtype->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_devtype
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLD_DEVTYPE.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_devtypeid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_devtype->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpld_devtype', 'm_tpld_devtype');
    }
}
?>